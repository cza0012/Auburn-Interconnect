using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUInterconnect
{
    public partial class EventEntryCntrl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string EventTitle
        {
            set { titleLink.Text = value; }
        }

        public string EventUrl
        {
            set { titleLink.NavigateUrl = value; }
        }

        public DateTime StartTime
        {
            set
            {
                timeLit.Text = value.ToString();
            }
        }
    }
}