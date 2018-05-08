using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateTameAddDays
{
    public class CustomDateTime : IDateTime
    {
        public DateTime Now()
        {
            return DateTime.Now.Date;
        }

        public void AddDays(DateTime date, double daysToAdd)
        {
            date.AddDays(daysToAdd);
        }

        public TimeSpan SubstractDays(DateTime date, int daysToSubtract)
        {
            return date.Subtract(DateTime.Parse($"{daysToSubtract}", CultureInfo.InvariantCulture));
        }
    }
}
