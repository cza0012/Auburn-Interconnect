using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace AUInterconnect
{
    public class FormatHelper
    {
        /// <summary>
        /// Strips all characters other than digits.
        /// </summary>
        /// <param name="str">The formatted string from UI.</param>
        /// <returns>A long representation of the phone number; If
        /// parsing error, 0 is returned.</returns>
        public static long ParsePhoneNum(string str)
        {
            StringBuilder s = new StringBuilder(str.Length);
            foreach (char c in str)
                if (char.IsDigit(c))
                    s.Append(c);

            long r = 0;
            return long.TryParse(s.ToString(), out r) ? r : 0;
            
        }
    }
}