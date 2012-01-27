using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUInterconnect
{
    public partial class AULayout1Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //User Identity and logout link.
            if (Session[Const.User] == null)
            {
                useridentity.Visible = false;
                UserNameLabel.Visible = false;

                LoginLink.Visible = true;
            }
            else
            {
                User user = (User)Session[Const.User];
                useridentity.Visible = true;
                UserNameLabel.Visible = true;
                UserNameLabel.Text = HttpUtility.HtmlEncode(user.FirstName);
                LoginLink.Visible = false;
            }
        }
    }
}