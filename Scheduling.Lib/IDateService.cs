using System;
using System.Collections.Generic;

namespace Scheduling.Lib
{
    public interface IDateService
    {

        /// <summary>
        /// Get dates for Scheduling
        /// </summary>
        /// <param name="weekStartDay">The start day of the week, considering satarday as default</param>
        /// <param name="numberOfDays">The number of days the schedule is for. By default it is set as 14 (2 weeks) </param>
        /// <returns></returns>
        IReadOnlyList<DateTime> GetDatesForScheduling(DayOfWeek weekStartDay = DayOfWeek.Saturday, int numberOfDays = 14);
    }
}
