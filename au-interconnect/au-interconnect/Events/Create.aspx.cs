using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
            if (string.IsNullOrEmpty(startDate.Text) ||
                string.IsNullOrEmpty(endDate.Text))
            {
                msgLbl.Text = "Start Time and End Time are required";
                return false;
            }

            DateTime startTime;
            DateTime endTime;
            if (!DateTime.TryParse(startDate.Text, out startTime))
            {
                msgLbl.Text = "Start Time is invalid";
                return false;
            }

            if (!DateTime.TryParse(endDate.Text, out endTime))
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
                "INSERT INTO Events (hostId, title, startTime, endTime, " +
                "location, descr, maxReg, maxGuest, adminOk, hostOk) " +
                "VALUES (@hostId, @title, @startTime, @endTime, " +
                "@location, @descr, @maxReg, @maxGuest, @adminOk, @hostOk)";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("hostId",
                    Session[Const.Uid]));
                command.Parameters.Add(new SqlParameter("title",
                    titleTxb.Text.Trim()));
                //command.Parameters.Add(new SqlParameter("startTime",
                //    startDate.DateTime));
                //command.Parameters.Add(new SqlParameter("endTime",
                //    endDate.DateTime));
                command.Parameters.Add(new SqlParameter("location",
                    locTxb.Text.Trim()));
                command.Parameters.Add(new SqlParameter("descr",
                    descTxb.Text.Trim()));
                command.Parameters.Add(
                    string.IsNullOrEmpty(maxRegTxb.Text.Trim())?
                    new SqlParameter("maxReg", DBNull.Value) :
                    new SqlParameter("maxReg", 
                        int.Parse(maxRegTxb.Text.Trim())));
                command.Parameters.Add(
                    string.IsNullOrEmpty(guestTxb.Text.Trim()) ?
                    new SqlParameter("maxGuest", DBNull.Value) :
                    new SqlParameter("maxGuest",
                        int.Parse(maxRegTxb.Text.Trim())));
                command.Parameters.Add(new SqlParameter("adminOk",
                    "0"));
                command.Parameters.Add(new SqlParameter("hostOk",
                    "1"));
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
    }
}