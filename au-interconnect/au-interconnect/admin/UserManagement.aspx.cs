using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AUInterconnect.admin
{
    public partial class UserManagement : System.Web.UI.Page
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

            //Check if user is Admin
            if (!user.IsAdministrator)
                Nav.GoHome(this);

            BuildUserTable();
        }

        private void BuildUserTable()
        {
            using (SqlDataReader reader = GetUsersReader())
            {
                while (reader.Read())
                {
                    TableCell[] cells = new TableCell[4];

                    //First Name
                    cells[0] = new TableCell();
                    cells[0].Text = reader["fname"].ToString();

                    //Last Name
                    cells[1] = new TableCell();
                    cells[1].Text = reader["lname"].ToString();

                    //Email
                    cells[2] = new TableCell();
                    cells[2].Text = reader["email"].ToString();

                    //Approved
                    cells[3] = new TableCell();
                    CheckBox checkBox = new CheckBox();
                    checkBox.AutoPostBack = true;
                    checkBox.EnableViewState = true;
                    checkBox.ViewStateMode = System.Web.UI.ViewStateMode.Inherit;
                    checkBox.ID = reader["uid"].ToString();
                    checkBox.Checked = (bool)reader["canReg"];
                    checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
                    cells[3].Controls.Add(checkBox);

                    TableRow row = new TableRow();
                    row.Cells.AddRange(cells);
                    userTbl.Rows.Add(row);

                    //string eventUrl = "Events/EventDetails.aspx?" +
                    //    Const.EventId + "=" + reader["id"];
                    //EventEntryCntrl entry =
                    //    (EventEntryCntrl)LoadControl("EventEntryCntrl.ascx");
                    //entry.EventTitle = reader["title"].ToString();
                    //entry.EventUrl = eventUrl;
                    //entry.StartTime = (DateTime)reader["startTime"];

                    //TableCell cell = new TableCell();
                    //TableRow row = new TableRow();
                    //cell.Controls.Add(entry);
                    //row.Cells.Add(cell);
                    //eventTbl.Rows.Add(row);
                                
                }
            }
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = null;

            try
            {
                //Get User ID
                CheckBox ckb = (CheckBox)sender;
                int userId = int.Parse(ckb.ID);
                string queryStr = "UPDATE Users SET canReg=@canReg WHERE uid=@uid";
                con = new SqlConnection(Config.SqlConStr);
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("canReg", ckb.Checked));
                command.Parameters.Add(new SqlParameter("uid", userId));
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Change the value of the checkbox back?
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        /// <summary>
        /// Get users based on filters set on the page.
        /// </summary>
        /// <returns></returns>
        private SqlDataReader GetUsersReader()
        {
            string queryStr = "SELECT * FROM Users " +
                BuildWhere();
            SqlConnection con = new SqlConnection(Config.SqlConStr);
            SqlCommand command = new SqlCommand(queryStr, con);
            command.Parameters.Add(new SqlParameter("v", filterTxb.Text.Trim()));
            con.Open();
            return command.ExecuteReader();
        }

        /// <summary>
        /// Build the WHERE cluse with SqlParameter.
        /// </summary>
        /// <returns>SQL WHERE clause; or empty string if no filter is filter
        /// is specified.</returns>
        private string BuildWhere()
        {
            if (filterTxb.Text.Trim() == string.Empty)
                return string.Empty;

            switch (filterLst.SelectedValue)
            {
                case "First Name":
                    return "WHERE fname=@v";
                case "Last Name":
                    return "WHERE lname=@v";
                case "Email":
                    return "WHERE email=@v";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Get the selected filter field. 0 = Last Name, 1 = First name,
        /// 2 = Email, -1 = Invalid.
        /// </summary>
        private int FilterCriteria
        {
            get
            {
                switch (filterLst.SelectedValue)
                {
                    case "Last Name":
                        return 0;
                    case "First Name":
                        return 1;
                    case "Email":
                        return 2;
                    default:
                        return -1;
                }
            }
        }
    }
}