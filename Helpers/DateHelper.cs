using System.Globalization;

namespace InventoryTrackApi.Helpers
{
    public static class DateHelper
    {
        public static bool TryParseDate(string dateString, out DateTime date)
        {
            return DateTime.TryParseExact(
                dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
    }
}
