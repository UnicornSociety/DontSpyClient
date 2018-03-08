﻿using System;

namespace DontSpy.Utils
{
    internal class TimeManagement
    {
        public static int UnixTimestampNow => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;

        public static DateTime UnixTimestampToDateTime(int unixTimestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimestamp);
        }
    }
}
