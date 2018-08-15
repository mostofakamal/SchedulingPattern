using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling.Lib.Entities
{
    public class Engineer: BaseEntity
    {
        public Engineer()
        {
            AssignedShifts = new List<Shift>();
        }
        public string Name { get; set; }

        public List<Shift> AssignedShifts { get; set; }

        public int AssignedMorningShiftCounts => AssignedShifts.Count(x => x.ShiftType == ShiftType.Morning);
        public int AssignedAfternoonShiftCounts => AssignedShifts.Count(x => x.ShiftType == ShiftType.Afternoon);

        /// <summary>
        /// The number of full shift day count is actually the min of Morning and afternoon count
        /// </summary>
        public int FullDayShiftCount => Math.Min(AssignedMorningShiftCounts, AssignedAfternoonShiftCounts);

    }
}