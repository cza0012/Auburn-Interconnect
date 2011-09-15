using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EventsSandbox
{
    public class Nav
    {
        /// <summary>
        /// Return to the page specified by "ReturnUrl" of the
        /// request object.
        /// </summary>
        /// <param name="thisPage">The current page</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ReturnToPrevPage(Page thisPage)
        {
            if (thisPage == null)
                throw new ArgumentNullException();

            string returnUrl = thisPage.Request["ReturnUrl"];
            if (returnUrl == null)
                returnUrl = "~/Default.aspx";
            thisPage.Response.Redirect(returnUrl, true);
        }

        /// <summary>
        /// Navigate to the Login page.
        /// </summary>
        /// <param name="page">The current request page</param>
        /// <param name="checkStudent">If to verify student on the login
        /// page.</param>
        public static void Login(Page page, bool checkStudent)
        {
            string returnUrl = HttpUtility.UrlEncode(
                page.Request.Url.ToString());
            string queryStr = "?ReturnUrl=" + returnUrl;
            if (checkStudent)
                queryStr += "&" + EventsSandbox.Login.AuthAuStud + "=1";
            string url = "~/User/Login.aspx" + queryStr;
            page.Response.Redirect(url, true);
            
        }
    }
}