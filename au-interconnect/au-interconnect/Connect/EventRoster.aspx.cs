using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AUInterconnect.Connect
{
    public partial class EventRoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Authentication



            if (!this.IsPostBack)
            {
                string queryStr = "SELECT fname, lname, email " +
                    "FROM EventRegs INNER JOIN Users ON userId=uid " +
                    "WHERE eventId=@eventId";

                int eventId = RequestUtil.GetEventId(Request);

                SqlConnection con = new SqlConnection(Config.SqlConStr);
                SqlCommand cmd = new SqlCommand(queryStr, con);
                cmd.Parameters.Add(new SqlParameter("eventId", eventId));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}