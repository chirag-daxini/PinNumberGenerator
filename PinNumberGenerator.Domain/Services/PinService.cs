using PinNumberGenerator.Messages;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PinNumberGenerator.Domain.Services
{
    public interface IPinService
    {
        Task<GenerateNewPinResponse> GeneratePin();
    }
    public class PinService : IPinService
    {
        public PinService()
        {

        }
        public async Task<GenerateNewPinResponse> GeneratePin()
        {
            var code = GenerateSecurityCode();
            return new GenerateNewPinResponse() { Pin = code };
        }

        private string GenerateSecurityCode()
        {
            var buffer = new byte[sizeof(ulong)];
            var cryptoRng = new RNGCryptoServiceProvider();
            cryptoRng.GetBytes(buffer);
            var num = BitConverter.ToUInt64(buffer, 0);
            var code = num % 10000;
            return code.ToString().PadLeft(4,'0');
        }
    }
}
