using Scheduling.Lib.Entities;

namespace Scheduling.Lib.Dtos
{
    public class ShiftDto
    {
        public ShiftDto(Shift shift)
        {
            this.EngineerId = shift.EngineerId;
            this.EngineerName = shift.Engineer.Name;
        }
        public string EngineerName { get; private set; }

        public int EngineerId { get; private set; }
    }
}