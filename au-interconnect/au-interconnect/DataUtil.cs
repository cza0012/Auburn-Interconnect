using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AUInterconnect
{
    public class DataUtil
    {
        public static DbConnection GetDbConnection()
        {
            // TODO: where to read connection name?
            String connectionName = "findMe";

            ConnectionStringSettings connStringSettings = ConfigurationManager.ConnectionStrings[connectionName];
            DbProviderFactory factory = DbProviderFactories.GetFactory(connStringSettings.ProviderName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connStringSettings.ConnectionString;
            return connection;
        }
    } 

}