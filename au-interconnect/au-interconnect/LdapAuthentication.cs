using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;

using System.Text;
using System.Collections;
using System.DirectoryServices;

namespace FormsAuthAD {

    /// <summary>
    /// Summary description for LdapAuthentication
    /// </summary>
    public class LdapAuthentication {
        private string _path;
        private string _filterAttribute;

        public LdapAuthentication() {
        }

        public LdapAuthentication(string path) {
            _path = path;
        }

        public bool IsAuthenticated(string domain, string username, string pwd) {
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
            try {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("givenName");
                search.PropertiesToLoad.Add("sn");
                SearchResult result = search.FindOne();
                if (null == result) {
                    return false;
                }
                // Update the new path to the user in the directory
                _path = result.Path;
                _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex) {
                throw new Exception("Error authenticating user. " + ex.Message);
            }
            return true;
        }
    }
}