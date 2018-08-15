using System;
using System.Collections.Generic;
using System.Linq;
using Scheduling.Lib.Utils;

namespace Scheduling.Lib
{
    /// <summary>
    /// The Date service class for providing scheduling dates
    /// </summary>
    public class DateService: IDateService
    {
        /// <summary>
        /// Get dates for Scheduling
        /// </summary>
        /// <param name="weekStartDay">The start day of the week, considering satarday as default</param>
        /// <param name="numberOfDays">The number of days the schedule is for. By default it is set as 14 (2 weeks) </param>
        /// <returns></returns>
        public IReadOnlyList<DateTime> GetDatesForScheduling(DayOfWeek weekStartDay = DayOfWeek.Saturday, int numberOfDays = 14)
        {
            var nextSatuday = DateTime.Today.GetNextDateOfTheDay(weekStartDay);
            // Get the exlcluded days 
            var excludeDays = GetExcludedDayOfWeeks();
            // Now generate a numberOfDays schedule starting from next saturday and exclude any day if it exists
            var dates = new List<DateTime>();

            for (var i = 1; i <= numberOfDays; i++)
            {
                dates.Add(nextSatuday.AddDays(i - 1));
            }
            if (excludeDays.Any())
            {
                dates = dates.Where(x => !excludeDays.Contains(x.DayOfWeek)).ToList();
            }
            return dates;
        }


        // Get the excluded days list on which there will be no shifts
        private List<DayOfWeek> GetExcludedDayOfWeeks()
        {
            return new List<DayOfWeek>();
        }
    }
}