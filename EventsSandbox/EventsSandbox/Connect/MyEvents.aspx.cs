using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EventsSandbox.Connect
{
    public partial class MyEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check user credential
#if DEBUG
            if (Session[Const.User] == null)
                Session[Const.User] = new User(1, true);
#endif
            User user = (User)Session[Const.User];
            if (user == null)
                Nav.Login(this, false);

            //Populate participation table
            LoadRegTable();

            //Populate host table
            LoadHostTable();
        }

        private void RemoveRegClick(object sender, EventArgs e)
        {
            ImageButton imgBtn = (ImageButton)sender;
            int eventId = int.Parse(imgBtn.Attributes["eventId"]);
            User user = (User)Session[Const.User];
            RemoveEventReg(user.Uid, eventId);
            for (int i = 0; i < partTbl.Rows.Count; i++)
            {
                TableCell cell = partTbl.Rows[i].Cells[1];
                ImageButton btn = (ImageButton)cell.Controls[0];
                if (btn == imgBtn)
                {
                    partTbl.Rows.RemoveAt(i);
                    break;
                }
            }
        }

        private void LoadRegTable()
        {
            //Load events from database
            try
            {
                using (SqlDataReader reader = GetMyRegEvents())
                {
                    while (reader.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cell = null;

                        string eventUrl = "~/Events/EventDetails.aspx?" +
                            Const.EventId + "=" + reader["eventId"];
                        
                        PartEventEntry entry =
                            (PartEventEntry)LoadControl("~/PartEventEntry.ascx");
                        entry.EventTitle = reader["title"].ToString();
                        entry.EventUrl = eventUrl;
                        entry.EventId = (int)reader["eventId"];
                        entry.StartTime = (DateTime)reader["startTime"];
                        cell = new TableCell();
                        cell.Controls.Add(entry);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        ImageButton imgBtn = new ImageButton();
                        imgBtn.ImageUrl = "~/images/calendar_week_remove.png";
                        imgBtn.Click += RemoveRegClick;
                        imgBtn.ToolTip = "Remove Event";
                        imgBtn.Attributes.Add("eventId", reader["eventId"].ToString());
                        cell.Controls.Add(imgBtn);
                        row.Cells.Add(cell);

                        partTbl.Rows.Add(row);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private SqlDataReader GetMyRegEvents()
        {
            string queryStr = "SELECT eventId, title, [Events].startTime " +
                "FROM EventRegs INNER JOIN [Events] ON eventId=[Events].id " +
                "WHERE userId=@userId ORDER BY [Events].startTime";
            
            int userId = ((User)Session[Const.User]).Uid;

            SqlConnection con = new SqlConnection(Config.SqlConStr);
            SqlCommand command = new SqlCommand(queryStr, con);
            command.Parameters.Add(new SqlParameter("userId", userId));
            con.Open();
            return command.ExecuteReader();
        }

        private void RemoveEventReg(int userId, int eventId)
        {
            string queryStr = "DELETE FROM EventRegs " +
                "WHERE userId=@userId AND eventId=@eventId";

            SqlConnection con = new SqlConnection(Config.SqlConStr);
            SqlCommand command = new SqlCommand(queryStr, con);
            command.Parameters.Add(new SqlParameter("userId", userId));
            command.Parameters.Add(new SqlParameter("eventId", eventId));
            con.Open();
            command.ExecuteNonQuery();
        }

        private void LoadHostTable()
        {
            //Load events from database
            try
            {
                using (SqlDataReader reader = GetMyHostEvents())
                {
                    while (reader.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cell = null;

                        string eventUrl = "~/Events/EventDetails.aspx?" +
                            Const.EventId + "=" + reader["id"];

                        PartEventEntry entry =
                            (PartEventEntry)LoadControl("~/PartEventEntry.ascx");
                        entry.EventTitle = reader["title"].ToString();
                        entry.EventUrl = eventUrl;
                        entry.EventId = (int)reader["id"];
                        entry.StartTime = (DateTime)reader["startTime"];
                        cell = new TableCell();
                        cell.Controls.Add(entry);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        HyperLink link = new HyperLink();
                        link.NavigateUrl = "EventRoster.aspx?" +
                            Const.EventId + '=' + reader["id"].ToString();
                        link.BorderStyle = BorderStyle.None;
                        link.BorderWidth = Unit.Pixel(0);
                        Image img = new Image();
                        img.ImageUrl = "~/images/view_list.gif";
                        img.ToolTip = "View Roster";
                        img.BorderStyle = BorderStyle.None;
                        link.Controls.Add(img);
                        cell.Controls.Add(link);
                        row.Cells.Add(cell);

                        hostTbl.Rows.Add(row);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private SqlDataReader GetMyHostEvents()
        {
            string queryStr = "SELECT id, title, startTime " +
                "FROM [Events] " +
                "WHERE hostId=@hostId ORDER BY startTime";

            int userId = ((User)Session[Const.User]).Uid;

            SqlConnection con = new SqlConnection(Config.SqlConStr);
            SqlCommand command = new SqlCommand(queryStr, con);
            command.Parameters.Add(new SqlParameter("hostId", userId));
            con.Open();
            return command.ExecuteReader();
        }
    }
}