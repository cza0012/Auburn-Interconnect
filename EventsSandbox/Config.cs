using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace EventsSandbox
{
    public class Config
    {
        public const string SqlConStrName = "oitss1.auburn.edu";

        /// <summary>
        /// Returns the SQL database connection string.
        /// </summary>
        /// <exception cref="ConfigurationErrorsException"></exception>
        public static string SqlConStr
        {
            get
            {
                return
                    ConfigurationManager.ConnectionStrings[
                    SqlConStrName].ConnectionString;
            }
        }
    }
}