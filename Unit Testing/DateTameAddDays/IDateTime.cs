using System;
using System.Collections.Generic;
using System.Text;

namespace DateTameAddDays
{
   public interface IDateTime
    {
        DateTime Now();

        void AddDays(DateTime date, double daysToAdd);

        TimeSpan SubstractDays(DateTime date, int daysToSubtract);
    }
}
