using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventsSandbox
{
    public partial class PartEventEntry : System.Web.UI.UserControl
    {
        public event EventHandler RemoveClick;

        private int eventId;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string EventTitle
        {
            set { titleLnk.Text = value; }
        }

        public string EventUrl
        {
            set { titleLnk.NavigateUrl = value; }
        }

        public int EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }

        public DateTime StartTime
        {
            set { startTimeLit.Text = value.ToString(); }
        }

        protected void RemoveLbtn_Click(object sender, EventArgs e)
        {
            SimpleEventArgs<int> eventArgs = new SimpleEventArgs<int>(eventId);
            RemoveClick(this, eventArgs);
        }


    }
}