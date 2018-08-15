namespace Scheduling.Lib.Dtos
{
    public class ScheduleDto
    {
        public int DayNo { get; set; }

        public string Date { get; set; }

        public ShiftDto MorningShift { get; set; }

        public ShiftDto AfternoonShift { get; set; }
    }
}
