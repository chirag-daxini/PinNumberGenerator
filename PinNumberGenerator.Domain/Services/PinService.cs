using PinNumberGenerator.Messages;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PinNumberGenerator.Domain.Services
{
    public interface IPinService
    {
        Task<GenerateNewPinResponse> GeneratePin();
    }
    public class PinService : IPinService
    {
        private readonly RandomNumberGenerator _crypto;
        private Regex regExNumber = new Regex(Constants.RegularExpression.DEFAULT_EXPRESSION);
        public PinService()
        {
            _crypto = RandomNumberGenerator.Create();
        }
        public async Task<GenerateNewPinResponse> GeneratePin()
        {
            var code = await GenerateSecurePin();
            return new GenerateNewPinResponse() { Pin = code };
        }
        private async Task<string> GenerateSecurePin()
        {
            var bytes = new byte[sizeof(ulong)];
            _crypto.GetBytes(bytes);
            var uint32 = BitConverter.ToUInt64(bytes, 0);
            var int31 = uint32 >> 1;
            var securePin = (int31 % 10000).ToString("D4");
            if (regExNumber.IsMatch(securePin))
                return await GenerateSecurePin();
            return securePin;
        }
    }
}
