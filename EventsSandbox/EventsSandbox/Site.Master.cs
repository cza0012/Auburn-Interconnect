﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventsSandbox
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //User Identity and logout link.
            if (Session[Const.User] == null)
            {
                logoutLnk.Visible = false;
                loginLnk.Visible = true;
                userPnl.Visible = false;
            }
            else
            {
                User user = (User)Session[Const.User];
                logoutLnk.Visible = true;
                loginLnk.Visible = false;
                userLit.Text = user.FirstName + ' ' + user.LastName; 
                userPnl.Visible = true;
            }
        }
    }
}
