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
    public partial class EventDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            if (Session[Const.User] == null)
                Session[Const.User] = new User(1);
#endif
            //Get the event ID
            string eidStr = Request[Const.EventId];
#if DEBUG
            if (eidStr == null) eidStr = "2";
#endif
            int eventId = 0;
            if (eidStr == null || !int.TryParse(eidStr, out eventId))
                Response.Redirect("~/Default.aspx", true);

            try
            {
                if(!PopulateEventInfo(eventId))
                    Response.Redirect("~/Default.aspx", true);
            }
            catch (Exception ex)
            { throw ex; }
        }

        private bool PopulateEventInfo(int eventId)
        {
            string queryStr = "SELECT eventName, startTime, endTime, location, " +
                "descr, hostName, meetTime, meetLocation, transportation, " +
                "costs, equipment FROM [Events] WHERE eventId=@eventId";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eventId", eventId));
                con.Open();
                SqlDataReader reader = command.ExecuteReader(
                    CommandBehavior.SingleRow);
                
                if (reader.Read())
                {
                    HostName.Text = reader["hostName"].ToString();
                    EventName.Text = reader["eventName"].ToString();
                    BigEventTime.Text = ((DateTime)reader["startTime"]).ToString("MMM d, yyyy");
                    StartTime.Text = ((DateTime)reader["startTime"]).ToString("MMM d, yyyy h:mm tt");
                    EndTime.Text = ((DateTime)reader["endTime"]).ToString("MMM d, yyyy h:mm tt");
                    Location.Text = reader["location"].ToString();
                    Desc.Text = reader["descr"].ToString().Replace(
                        "\r\n", "<br />").Replace("\n", "<br />");
                    MeetTime.Text = ((DateTime)reader["startTime"]).ToString("MMM d, yyyy h:mm tt");
                    MeetLocation.Text = reader["meetLocation"].ToString();
                    Transportation.Text = reader["transportation"].ToString();
                    Costs.Text = reader["costs"].ToString();
                    Equipments.Text = reader["equipment"].ToString();
                    
                    //Space
                    //if (reader["maxReg"] == DBNull.Value)
                    //{
                    //    spaceLit.Text = "This event has no limit on the " +
                    //        "number of participants.";
                    //}
                    //else
                    //{
                    //    int maxReg = (int)reader["maxReg"];
                    //    spaceLit.Text = "There are total " + maxReg +
                    //        "spaces for this event.";
                    //}
                    
                    return true;
                }
                else { return false; }
            }
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            int eventId = RequestUtil.GetEventId(Request);
            string url = "~/Events/Signup.aspx?" + Const.EventId + '=' + eventId;
            Response.Redirect(url, true);
        }
    }
}