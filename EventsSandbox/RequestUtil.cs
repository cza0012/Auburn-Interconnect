using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsSandbox
{
    public class RequestUtil
    {
        /// <summary>
        /// Get Event ID from request object.
        /// </summary>
        /// <returns>-1 if event ID is not found.</returns>
        public static int GetEventId(HttpRequest request)
        {
            int eid = -1;
            int.TryParse(request[Const.EventId], out eid);
#if DEBUG
            if(eid == -1)
                eid = 1;
#endif
            return eid;
        }
    }
}