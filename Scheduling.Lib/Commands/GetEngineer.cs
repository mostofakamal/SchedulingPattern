using System.Collections.Generic;
using MediatR;
using Scheduling.Lib.Dtos;

namespace Scheduling.Lib.Commands
{
    public class GetEngineer: IRequest<List<EngineerDto>>
    {
    }
}
