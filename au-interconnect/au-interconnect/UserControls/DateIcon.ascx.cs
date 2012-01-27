using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUInterconnect.UserControls
{
    public partial class DateIcon : System.Web.UI.UserControl
    {
        private DateTime date;

        public DateIcon()
        {
        }
        
        public DateIcon(DateTime date)
        {
            this.date = date;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowDate();
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                ShowDate();
            }
        }

        private void ShowDate()
        {
            MonthLabel.Text = date.ToString("MMM").ToUpper();
            DayLabel.Text = date.ToString("dd");
        }
    }
}