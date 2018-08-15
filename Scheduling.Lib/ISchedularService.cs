using System.Collections.Generic;
using Scheduling.Lib.Entities;

namespace Scheduling.Lib
{
    public interface ISchedularService
    {
        List<Schedule> GenerateSchedule();
    }
}