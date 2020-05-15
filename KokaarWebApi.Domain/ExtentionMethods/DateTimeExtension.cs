using System;

namespace KokaarWebApi.Domain.ExtentionMethods
{
    public static class DateTimeExtension
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTime.Year;

            if (currentDate < dateTime.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
