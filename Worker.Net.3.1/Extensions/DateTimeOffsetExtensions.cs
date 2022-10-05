using System;
using TimeZoneConverter;

namespace Worker.Net._3._1.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset ConvertToBraziliaTimeZone(this DateTimeOffset date)
        {
            var timezonesInstalled = TimeZoneInfo.GetSystemTimeZones();

            //windows ou linux (necessário usar se net < 6)
            var brasiliaTimezone = TZConvert.GetTimeZoneInfo("E. South America Standard Time");

            //não funciona no linux se net < 6
            //var brasiliaTimezone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            var convertedDate = TimeZoneInfo.ConvertTime(date, brasiliaTimezone);
            return convertedDate;
        }
    }
}
