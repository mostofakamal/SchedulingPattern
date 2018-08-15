using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scheduling.Lib.Commands;
using Scheduling.Lib.Dtos;
using Scheduling.Lib.Entities;

namespace Scheduling.Lib.CommandHandlers
{
    public class GetEngineerHandler: IRequestHandler<GetEngineer,List<EngineerDto>>
    {
        private readonly IEmployeeService _employeeService;
        public GetEngineerHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Task<List<EngineerDto>> Handle(GetEngineer request, CancellationToken cancellationToken)
        {
            var engineers = _employeeService.GetEngineers().Select(x=> new EngineerDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Task.FromResult(engineers);
        }
    }
}
