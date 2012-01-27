﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUInterconnect.UserControls;
using AUInterconnect.DataModel;
using System.Data.SqlClient;

namespace AUInterconnect.Host
{
    public partial class HostActiveEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Make sure the user is logged in and is a host.
            PageHelper.LoginAsHost(this, false);

            FillEvents();
        }

        private void FillEvents()
        {
            User user = (User)Session[Const.User];
            SqlDataReader reader =
                DataModel.Host.GetDataReaderActiveEvents(user.Uid);
            try
            {
                using (reader)
                {
                    while (reader.Read())
                    {

                        HostEvent eventInfo =
                            (HostEvent)LoadControl("~/UserControls/HostEvent.ascx");
                        eventInfo.SetEventName((int)reader["eventId"],
                            reader["eventName"].ToString());
                        eventInfo.StartTime = (DateTime)reader["startTime"];

                        TableCell cell = new TableCell();
                        TableRow row = new TableRow();
                        cell.Controls.Add(eventInfo);
                        cell.CssClass = "eventCell";
                        row.Cells.Add(cell);
                        EventTable.Rows.Add(row);

                    }
                }
            }
            catch (Exception)
            {
                //TODO:Display and log exception.
            }
        }


    }
}