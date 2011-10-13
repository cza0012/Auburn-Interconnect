using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUInterconnect.admin
{
    public partial class EventApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

#if DEBUG
            if (Session[Const.User] == null)
                Session[Const.User] = new User(1, true);
#endif
            User user = (User)Session[Const.User];
            if (user == null)
                Nav.Login(this, false);

            //Check if user is Admin
            if (!user.IsAdministrator)
                Nav.GoHome(this);

            // load events table

            Boolean showOld = "1".Equals(Request.Params["showOld"]);
            
            LoadEventsTable(GetEventsReader(showOld));

            FilterLink.Text = showOld ? "Show Unseen Events" : "Show Processed Events";
            FilterLink.NavigateUrl = showOld ? "~/admin/EventApproval.aspx" : "~/admin/EventApproval.aspx?showOld=1";
        }

        protected void LoadEventsTable(SqlDataReader reader)  {
            //Load events from database
            try
            {
                using (reader)
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
                        Literal status = new Literal();
                        status.ID = "status_" + reader["id"].ToString();
                        status.Text = (bool)reader["eventSeen"] ? ((bool)reader["adminOk"] ? "<em>Approved</em>" : "<em>Denied</em>") : "";
                        cell.Controls.Add(status);
                        row.Cells.Add(cell);                        

                        cell = new TableCell();
                        Button approveBtn = new Button();
                        approveBtn.UseSubmitBehavior = false;
                        approveBtn.ID = "approve_btn_" + reader["id"].ToString();
                        approveBtn.Click += ApproveEvent;
                        approveBtn.Text = "Approve";                        
                        cell.Controls.Add(approveBtn);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        Button denyBtn = new Button();
                        denyBtn.UseSubmitBehavior = false;
                        denyBtn.ID = "deny_btn_" + reader["id"].ToString();
                        denyBtn.Click += DenyEvent;
                        denyBtn.Text = "Deny";                        
                        cell.Controls.Add(denyBtn);
                        row.Cells.Add(cell);

                        Events.Rows.Add(row);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void DenyEvent(object sender, EventArgs e)
        {
            string queryStr = "UPDATE [Events] SET adminOk=0, eventSeen=1 WHERE id=@eventId";

            Button btn = (Button)sender;

            SqlConnection con = new SqlConnection(Config.SqlConStr);
            SqlCommand command = new SqlCommand(queryStr, con);
            command.Parameters.Add(new SqlParameter("eventId", btn.ID.Replace("deny_btn_", "")));
            con.Open();
            command.ExecuteNonQuery();

            Literal status = (Literal)FindControlRecursive(btn.Parent.Parent, "status_" + btn.ID.Replace("deny_btn_", ""));

            status.Text = "<em>Denied</em>";
        }

        protected void ApproveEvent(object sender, EventArgs e)
        {
            string queryStr = "UPDATE [Events] SET adminOk=1, eventSeen=1 WHERE id=@eventId";

            Button btn = (Button)sender;

            SqlConnection con = new SqlConnection(Config.SqlConStr);
            SqlCommand command = new SqlCommand(queryStr, con);
            command.Parameters.Add(new SqlParameter("eventId", btn.ID.Replace("approve_btn_", "")));
            con.Open();
            command.ExecuteNonQuery();

            Literal status = (Literal)FindControlRecursive(btn.Parent.Parent, "status_" + btn.ID.Replace("approve_btn_", ""));

            status.Text = "<em>Approved</em>";
        }


        private SqlDataReader GetEventsReader(Boolean showOld)
        {
            string queryStr = "SELECT id, hostId, title, startTime, adminOk, eventSeen " +
                "FROM [Events] " +
                "WHERE eventSeen=@eventSeen ORDER BY startTime";

            SqlConnection con = new SqlConnection(Config.SqlConStr);
            SqlCommand command = new SqlCommand(queryStr, con);
            command.Parameters.Add(new SqlParameter("eventSeen", showOld));
            con.Open();
            return command.ExecuteReader();
        }

        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn = FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;
        }

    }
}