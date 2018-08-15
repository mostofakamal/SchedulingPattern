using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scheduling.Lib.Commands;
using Scheduling.Lib.Dtos;
using Scheduling.Lib.Utils;

namespace Scheduling.Lib.CommandHandlers
{
    public class GenerateScheduleHandler : IRequestHandler<GenerateSchedule, List<ScheduleDto>>
    {
        private readonly ISchedularService _schedularService;

        public GenerateScheduleHandler(ISchedularService schedularService)
        {
            _schedularService = schedularService;
        }
        public Task<List<ScheduleDto>> Handle(GenerateSchedule request, CancellationToken cancellationToken)
        {
            var schedules = _schedularService.GenerateSchedule();
            var mappedData = schedules.Select(schedule => schedule.MapToDto()).ToList();
            return Task.FromResult(mappedData);
        }
    }
}