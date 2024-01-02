namespace ProjectManagementApi.Helper
{
    public static class DateTimeHelper
    {
        public static (int, int) ConvertToClarion(DateTime dt)
        {
            DateTime datePart = dt.Date;
            TimeSpan timePart = dt.TimeOfDay;
            DateTime baseDate = new DateTime(1800, 12, 28);

            (int, int) result = ((datePart - baseDate).Days, (int)(timePart.TotalSeconds * 100));
        
            return result;
        }
    }
}
