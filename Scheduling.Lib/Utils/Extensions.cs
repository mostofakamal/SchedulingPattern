using System;
using System.Collections.Generic;
using System.Linq;
using Scheduling.Lib.Dtos;
using Scheduling.Lib.Entities;

namespace Scheduling.Lib.Utils
{
    public static class Extensions
    {

        /// <summary>
        /// This maps schedule class object to respective DTO
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public static ScheduleDto MapToDto(this Schedule schedule)
        {
            return new ScheduleDto
            {
                DayNo = schedule.DayNo,
                Date = schedule.Date.ToString("dd.MM.yyyy"),
                MorningShift = new ShiftDto(schedule.MorningShift),
                AfternoonShift = new ShiftDto(schedule.AfternoonShift)
            };
        }

        
        /// <summary>
        /// The extension method for shuffling an IEnumerable collection so that we can skip item randomly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }

        private static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random randomNumberGenerator)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (randomNumberGenerator == null) throw new ArgumentNullException(nameof(randomNumberGenerator));

            return source.ShuffleIterator(randomNumberGenerator);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (var i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

        /// <summary>
        /// The extension method for getting the next nearest date of the day specified startDate
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="desiredDay"></param>
        /// <returns></returns>
        public static DateTime GetNextDateOfTheDay(this DateTime startDate, DayOfWeek desiredDay)
        {
            var nextDate = startDate;
            while (nextDate.DayOfWeek != desiredDay)
                nextDate = nextDate.AddDays(1D);

            return nextDate;
        }

        
    }

   
}
