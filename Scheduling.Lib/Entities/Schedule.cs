using System;

namespace Scheduling.Lib.Entities
{
    public class Schedule
    {
        public Schedule(int dayNo, DateTime date)
        {
            Id = Guid.NewGuid();
            this.DayNo = dayNo;
            this.Date = date;
            MorningShift = new Shift {ShiftType = ShiftType.Morning, ScheduleId = Id, Schedule = this, DayNo = dayNo};
            AfternoonShift = new Shift {ShiftType = ShiftType.Afternoon, ScheduleId = Id , Schedule = this, DayNo = dayNo };
        }

        public Guid Id { get; set; }
        public int DayNo { get; set; }

        public DateTime Date { get; set; }

        public Shift MorningShift { get; set; }

        public Shift AfternoonShift { get; set; }

       
    }
}