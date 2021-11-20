using Acme.Ports.Manager.Core.Ports.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Ports.Manager.Api.Controllers
{
    [ApiController]
    [Route("v1/ports")]
    public class PortsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PortsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePortCommand command)
        {
            var response = _mediator.Send(command);
            return Created($"v1/ports/{response.Result.Id}", response.Result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success");
        }
    }
}