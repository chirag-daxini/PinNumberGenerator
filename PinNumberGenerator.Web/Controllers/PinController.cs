using Microsoft.AspNetCore.Mvc;
using PinNumberGenerator.Messages;
using System.Threading.Tasks;

namespace PinNumberGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : ControllerBase
    {
        public PinController()
        {

        }
        [HttpGet]
        public async Task<GenerateNewPinResponse> GetNextPin()
        {
            return null;
        }
    }
}
