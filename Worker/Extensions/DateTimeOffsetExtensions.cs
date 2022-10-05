namespace Worker.Net6.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset ConvertToBraziliaTimeZone(this DateTimeOffset date)
        {
            var timezonesInstalled = TimeZoneInfo.GetSystemTimeZones();
            var brasiliaTimezone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var convertedDate = TimeZoneInfo.ConvertTime(date, brasiliaTimezone);
            return convertedDate;
        }
    }
}
