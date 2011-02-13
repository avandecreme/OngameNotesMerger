using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IrfParserNs
{
    public static class TimestampHelper
    {
        private static readonly DateTime UnixStart = new DateTime(1970, 1, 1);

        public static DateTime GetDateTime(double timestamp)
        {
            return UnixStart.AddSeconds(timestamp);
        }

        public static double GetTimestamp(DateTime date)
        {
            TimeSpan diff = date - UnixStart;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}
