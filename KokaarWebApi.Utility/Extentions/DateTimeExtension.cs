using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWebApi.Utility.Extentions
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
