using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EventsSandbox.Events
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            if (Session[Const.User] == null)
                Session[Const.User] = new User(1, true);
#endif
            User user = (User)Session[Const.User];
            if (user == null || !user.IsAuStudent)
            {
                string returnUrl = HttpUtility.UrlEncode(
                    Request.Url.ToString());
                string queryStr = "?" +
                    EventsSandbox.Login.AuthAuStud + "=1" +
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
            string queryStr = "SELECT title FROM [Events] " +
                "WHERE id=@id";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", eventId));
                con.Open();
                SqlDataReader reader = command.ExecuteReader(
                    CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    titleLit.Text = reader["title"].ToString();
                }
            }
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            int eventId = RequestUtil.GetEventId(Request);
            int addInvite = 0;
            int.TryParse(addTxb.Text.Trim(), out addInvite);
            int userId = ((User)Session[Const.User]).Uid;

            try
            {
                RegisterEvent(eventId, userId, addInvite);
                Nav.ReturnToPrevPage(this);
            }
            catch (Exception ex)
            {
                ErrorLit.Text = ex.Message;
            }
        }

        private void RegisterEvent(int eventId, int userId, int ext)
        {
            //Check if event is full
            if (Event.IsFull(eventId))
            {
                ErrorLit.Text = "We're sorry the event is full.";
                regBtn.Enabled = false;
                return;
            }

            string queryStr = "INSERT INTO EventRegs " +
                "(eventId, userId, extInvite) VALUES " +
                "(@eid, @uid, @ext)";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eid",
                    eventId));
                command.Parameters.Add(new SqlParameter("uid",
                    userId));
                command.Parameters.Add(new SqlParameter("ext",
                    ext));

                con.Open();
                int r = command.ExecuteNonQuery();
            }
        }

    }
}