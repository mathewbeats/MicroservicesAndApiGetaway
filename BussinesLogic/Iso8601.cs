using System.Globalization;

namespace Microservices.BussinesLogic
{
    public static class Iso8601
    {
        public static string ToIso8601DateString(this DateTime date)
        {
            return date.ToString(
                "yyyy'-'MM'-'dd",
                CultureInfo.InvariantCulture);
        }

        public static string ToIso8601TimeString(this TimeSpan time)
        {
            return time.ToString("T", CultureInfo.InvariantCulture);
        }

        public static string ToIso8601DateTimeString(this DateTime date)
        {
            return date.ToString("o", CultureInfo.InvariantCulture);
        }
    }
}
