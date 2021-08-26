using MediatR;
using PinNumberGenerator.Domain.Services;
using PinNumberGenerator.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace PinNumberGenerator.Domain.Handlers
{
    public class GeneratePinHandler : IRequestHandler<GenerateNewPinRequest, GenerateNewPinResponse>
    {
        private readonly IPinService _pinService;

        public GeneratePinHandler(IPinService pinService)
        {
            _pinService = pinService;
        }

        public async Task<GenerateNewPinResponse> Handle(GenerateNewPinRequest request, CancellationToken cancellationToken)
        {
            return await _pinService.GeneratePin();
        }
    }
}
