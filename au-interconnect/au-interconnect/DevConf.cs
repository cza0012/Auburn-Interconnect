﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUInterconnect
{
    public class DevConf
    {
        public const int DebugEventId = 2;
        public const int DebugUserId = 1;

        public static string DebugEventIdStr
        {
            get { return DebugEventId.ToString(); }
        }
    }
}