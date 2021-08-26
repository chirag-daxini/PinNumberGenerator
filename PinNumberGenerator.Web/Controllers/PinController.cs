using MediatR;
using Microsoft.AspNetCore.Mvc;
using PinNumberGenerator.Messages;
using System.Threading.Tasks;

namespace PinNumberGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PinController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<GenerateNewPinResponse> GetNextPin()
        {
            return await _mediator.Send(new GenerateNewPinRequest());
        }
    }
}
