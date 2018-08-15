using System;

namespace Scheduling.Lib.Entities
{
    public class Shift
    {
        public Shift()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        public int DayNo { get; set; }

        public int EngineerId { get; set; }

        public Engineer Engineer { get; set; }

        public ShiftType ShiftType { get; set; }
    }
}