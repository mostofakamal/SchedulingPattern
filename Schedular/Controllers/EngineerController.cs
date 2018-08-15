using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Lib.Commands;

namespace Schedular.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Engineer")]
    public class EngineerController : Controller
    {
        private readonly IMediator _mediator;
        public EngineerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get list of all engineers in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetEngineer());
            return Json(response);
        }
    }
}