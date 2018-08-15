using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Lib.Commands;

namespace Schedular.API.Controllers
{
    /// <summary>
    /// Support employee scheduling
    /// </summary>
    [Produces("application/json")]
    [Route("api/schedule")]
    public class ScheduleController : Controller
    {
        private readonly IMediator _mediator;
        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the schedule for Support 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSchedule()
        {
            var response = await _mediator.Send(new GenerateSchedule());
            return Json(response);

        }
    }

    
}