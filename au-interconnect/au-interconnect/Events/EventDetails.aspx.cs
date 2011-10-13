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
            if (eidStr == null) eidStr = "1";
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
            string queryStr = "SELECT title, startTime, endTime, location, " +
                "descr, maxReg, maxGuest, fname, lname FROM [Events] " +
                "INNER JOIN Users ON hostId=uid WHERE id=@id";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", eventId));
                con.Open();
                SqlDataReader reader = command.ExecuteReader(
                    CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    hostLit.Text = reader["fName"].ToString() + " " +
                        reader["lname"].ToString();
                    titleLit.Text = reader["title"].ToString();
                    startLit.Text = ((DateTime)reader["startTime"]).ToString("f");
                    endLit.Text = ((DateTime)reader["endTime"]).ToString("f");
                    locLit.Text = reader["location"].ToString();
                    descLit.Text = reader["descr"].ToString().Replace(
                        "\r\n", "<br />").Replace("\n", "<br />");
                    
                    //Space
                    if (reader["maxReg"] == DBNull.Value)
                    {
                        spaceLit.Text = "This event has no limit on the " +
                            "number of participants.";
                    }
                    else
                    {
                        int maxReg = (int)reader["maxReg"];
                        spaceLit.Text = "There are total " + maxReg +
                            "spaces for this event.";
                    }
                    
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