using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AUInterconnect.Events
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            User debUser = (User)Session[Const.User];
            if (debUser == null)
            {
                debUser = new User(1, true);
                Session[Const.User] = debUser;
            }
            debUser.IsAuStudent = true;
#endif
            User user = (User)Session[Const.User];
            if (user == null || !user.IsAuStudent)
            {
                string returnUrl = HttpUtility.UrlEncode(
                    Request.Url.ToString());
                string queryStr = "?" +
                    AUInterconnect.Login.AuthAuStud + "=1" +
                    "&ReturnUrl=" + returnUrl;
                string url = "~/User/Login.aspx" + queryStr;
                Response.Redirect(url, true);
            }

            //Get the event ID
            string eidStr = Request[Const.EventId];
#if DEBUG
            if (eidStr == null) eidStr = "1";
#endif
            int eventId = 0;
            if (eidStr == null || !int.TryParse(eidStr, out eventId))
                Response.Redirect("~/Default.aspx", true);

            PopulateForm(eventId);

            //Check if event is full
            if (Event.IsFull(eventId))
            {
                ErrorLit.Text = "We're sorry the event is full.";
                regBtn.Enabled = false;
            }
        }

        private void PopulateForm(int eventId)
        {
            string queryStr = "SELECT eventName, hostOrg, hostName, startTime " +
                " FROM [Events] WHERE eventId=@eventId";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eventId", eventId));
                con.Open();
                SqlDataReader reader = command.ExecuteReader(
                    CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    EventName.Text = reader["eventName"].ToString();
                    EventHost.Text = ((reader["hostOrg"] == DBNull.Value) ?
                        reader["hostName"].ToString() :
                        reader["hostName"].ToString());
                    Date.Text = ((DateTime)reader["startTime"]).ToString("MMM d, yyyy");
                    Time.Text = ((DateTime)reader["startTime"]).ToString("h:mm tt");
                        
                }
            }
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            //TODO: validate head count and vehicle cap (not negative).
            //TODO: make sure the user has not registered for this event.

            int eventId = RequestUtil.GetEventId(Request);

#if DEBUG
            if (eventId == 0)
                eventId = 1;
#endif

            int headCount = 0;
            int vehicleCap = 0;
            int.TryParse(HeadCount.Text.Trim(), out headCount);
            int.TryParse(VehicleCap.Text.Trim(), out vehicleCap);
            
            int userId = ((User)Session[Const.User]).Uid;

            try
            {
                RegisterEvent(eventId, userId, headCount, vehicleCap);
                Nav.ReturnToPrevPage(this);
            }
            catch (Exception ex)
            {
                ErrorLit.Text = ex.Message;
            }
        }

        private void RegisterEvent(int eventId, int userId, int headCount,
            int vehicleCap)
        {
            //Check if event is full
            if (Event.IsFull(eventId))
            {
                ErrorLit.Text = "We're sorry the event is full.";
                regBtn.Enabled = false;
                return;
            }

            string queryStr = "INSERT INTO EventRegs " +
                "(eventId, userId, headCount, vehicleCap) VALUES " +
                "(@eid, @uid, @headCount, @vehicleCap)";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eid",
                    eventId));
                command.Parameters.Add(new SqlParameter("uid",
                    userId));
                command.Parameters.Add(new SqlParameter("headCount",
                    headCount));
                command.Parameters.Add(new SqlParameter("vehicleCap",
                    vehicleCap));

                con.Open();
                int r = command.ExecuteNonQuery();
            }
        }

    }
}