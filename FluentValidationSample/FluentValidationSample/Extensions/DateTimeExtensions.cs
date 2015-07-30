using System;

namespace FluentValidationSample.Extensions
{
    public static class DateTimeExtensions
    {
        public static int AgeAt(this DateTime dt, DateTime? atDate = null)
        {
            var ageAtDate = atDate.GetValueOrDefault(DateTime.UtcNow).Date;
            var age = ageAtDate.Year - dt.Year;
            if (dt > ageAtDate.AddYears(-age)) age--;
            return age;
        }
    }
}