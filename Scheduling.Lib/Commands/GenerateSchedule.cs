using System.Collections.Generic;
using MediatR;
using Scheduling.Lib.Dtos;

namespace Scheduling.Lib.Commands
{
    /// <summary>
    /// The Command for GenerateSchedule it has associated handler to handle this
    /// It returns a List of schedule Dto object
    /// </summary>
    public class GenerateSchedule : IRequest<List<ScheduleDto>>
    {

    }
}