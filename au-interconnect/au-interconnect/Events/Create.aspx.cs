using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

namespace AUInterconnect.Events
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if user is logged in
#if DEBUG
            if(Session[Const.User] == null)
                Session[Const.User] = new User(1, true);
#endif
            if (Session[Const.User] == null)
            {
                string returnUrl = HttpUtility.UrlEncode(
                    Request.Url.ToString());
                string url = "~/User/Login.aspx?ReturnUrl=" + returnUrl;
                Response.Redirect(url, true);
            }
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    decimal eventId = CreateEvent();
                    Nav.ReturnToPrevPage(this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateInput()
        {
            return ValidateEventTimes()
                && ValidateAgreeCondition();
        }

        private bool ValidateEventTimes()
        {
            //Check that start and end time are present
            if (string.IsNullOrEmpty(StartTime.Text) ||
                string.IsNullOrEmpty(EndTime.Text))
            {
                msgLbl.Text = "Start Time and End Time are required";
                return false;
            }

            DateTime startTime;
            DateTime endTime;
            if (!DateTime.TryParse(StartTime.Text, out startTime))
            {
                msgLbl.Text = "Start Time is invalid";
                return false;
            }

            if (!DateTime.TryParse(EndTime.Text, out endTime))
            {
                msgLbl.Text = "End Time is invalid";
                return false;
            }

            //Check that start time is not before end time
            if (startTime.CompareTo(endTime) > 0)
            {
                msgLbl.Text = "Start time must come before end time";
                return false;
            }

            return true;
        }

        private bool ValidateAgreeCondition()
        {
            if (!agreeChk.Checked)
            {
                msgLbl.Text = "You must agree conditions";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Insert a new event into the database and return the event ID.
        /// </summary>
        /// <returns>-1 if event not inserted.</returns>
        private decimal CreateEvent()
        {
            string queryStr =
                "INSERT INTO Events (creatorId, createTime, guestLimit, hostOrg, " +
                "hostName, hostEmail, hostPhone, eventName, startTime, endTime, " +
                "location, descr, meetLocation, meetTime, transportation, requestDrivers, " +
                "costs, equipment, food, other) " +
                "VALUES (@creatorId, @createTime, @guestLimit, @hostOrg, @hostName, " +
                "@hostEmail, @hostPhone, @eventName, @startTime, @endTime, " +
                "@location, @descr, @meetLocation, @meetTime, @transportation, " +
                "@requestDrivers, @costs, @equipment, @food, @other)";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("creatorId",
                    ((User)Session[Const.User]).Uid));
                command.Parameters.Add(new SqlParameter("createTime",
                    DateTime.Now));
                command.Parameters.Add(
                   string.IsNullOrEmpty(GuestLimit.Text.Trim()) ?
                   new SqlParameter("guestLimit", DBNull.Value) :
                   new SqlParameter("guestLimit",
                       int.Parse(GuestLimit.Text.Trim())));
                command.Parameters.Add(
                    string.IsNullOrEmpty(HostOrg.Text.Trim()) ?
                    new SqlParameter("hostOrg", DBNull.Value) :
                    new SqlParameter("hostOrg", HostOrg.Text.Trim()));
                command.Parameters.Add(new SqlParameter("hostName",
                    HostName.Text.Trim()));
                command.Parameters.Add(new SqlParameter("hostEmail",
                    HostEmail.Text.Trim()));
                command.Parameters.Add(new SqlParameter("hostPhone",
                    ParsePhoneNum(HostPhone.Text)));
                command.Parameters.Add(new SqlParameter("eventName",
                    EventName.Text.Trim()));
                command.Parameters.Add(new SqlParameter("startTime",
                    DateTime.Parse(StartTime.Text)));
                command.Parameters.Add(new SqlParameter("endTime",
                    DateTime.Parse(EndTime.Text)));
                command.Parameters.Add(new SqlParameter("location",
                    Location.Text.Trim()));
                command.Parameters.Add(new SqlParameter("descr",
                    Desc.Text.Trim()));
                command.Parameters.Add(new SqlParameter("meetLocation",
                    MeetLocation.Text.Trim()));
                command.Parameters.Add(new SqlParameter("meetTime",
                    DateTime.Parse(MeetTime.Text)));
                command.Parameters.Add(new SqlParameter("transportation",
                    Transport.Text.Trim()));
                command.Parameters.Add(new SqlParameter("requestDrivers",
                    RequestDrivers.Checked));
                command.Parameters.Add(
                    string.IsNullOrEmpty(Costs.Text.Trim()) ?
                    new SqlParameter("costs", DBNull.Value) :
                    new SqlParameter("costs", Costs.Text.Trim()));
                command.Parameters.Add(
                    string.IsNullOrEmpty(Equipment.Text.Trim()) ?
                    new SqlParameter("equipment", DBNull.Value) :
                    new SqlParameter("equipment", Equipment.Text.Trim()));
                command.Parameters.Add(
                    string.IsNullOrEmpty(Food.Text.Trim()) ?
                    new SqlParameter("food", DBNull.Value) :
                    new SqlParameter("food", Food.Text.Trim()));
                command.Parameters.Add(
                    string.IsNullOrEmpty(Other.Text.Trim()) ?
                    new SqlParameter("other", DBNull.Value) :
                    new SqlParameter("other", Other.Text.Trim()));

                //command.Parameters.Add(
                //    string.IsNullOrEmpty(maxRegTxb.Text.Trim())?
                //    new SqlParameter("maxReg", DBNull.Value) :
                //    new SqlParameter("maxReg", 
                //        int.Parse(maxRegTxb.Text.Trim())));
                //command.Parameters.Add(
                //    string.IsNullOrEmpty(guestTxb.Text.Trim()) ?
                //    new SqlParameter("maxGuest", DBNull.Value) :
                //    new SqlParameter("maxGuest",
                //        int.Parse(maxRegTxb.Text.Trim())));
                //command.Parameters.Add(new SqlParameter("adminOk",
                //    "0"));
                //command.Parameters.Add(new SqlParameter("hostOk",
                //    "1"));
                con.Open();
                int r = command.ExecuteNonQuery();

                if (r < 1)
                    return -1;

                //Get the ID of the event created.
                queryStr = "SELECT @@IDENTITY";
                command = new SqlCommand(queryStr, con);
                object o = command.ExecuteScalar();
                return (decimal)o;
            }
        }

        public static long ParsePhoneNum(string str)
        {
            StringBuilder result = new StringBuilder(str.Length);
            foreach (char c in str)
                if (char.IsDigit(c))
                    result.Append(c);
            return long.Parse(result.ToString());
        }
    }
}