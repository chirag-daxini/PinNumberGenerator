using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinNumberGenerator.Domain.Services;
using PinNumberGenerator.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PinNumberGenerator.Tests
{
    [TestClass]
    public class PinServiceTests
    {
        private PinService _pinService;
        private Regex regExNumber = new Regex(Constants.RegularExpression.DEFAULT_EXPRESSION);

        [TestInitialize]
        public void Intialize()
        {
            _pinService = new PinService();
        }
        [TestMethod]
        public async Task Should_Generate_Unique_Pin()
        {
            List<GenerateNewPinResponse> responses = new List<GenerateNewPinResponse>();
            for (int i = 0; i < 100; i++)
            {
                responses.Add(await _pinService.GeneratePin());
            }

            var duplicates = responses
                .GroupBy(i => i.Pin)
                 .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            Assert.IsFalse(duplicates.Any());
        }
        [TestMethod]
        public async Task Should_Generate_UniquePin_Length_Of_four()
        {
            var generatedPin = await _pinService.GeneratePin();

            Assert.IsTrue(generatedPin.Pin.Length == 4);
        }
        [TestMethod]
        public async Task Should_Not_Generate_ObviousNumber()
        {
            List<GenerateNewPinResponse> responses = new List<GenerateNewPinResponse>();
            for (int i = 0; i < 10; i++)
            {
                responses.Add(await _pinService.GeneratePin());
            }
            Assert.IsFalse(responses.Any(x => isObiviousNumber(x.Pin)));
        }
        private bool isObiviousNumber(string phoneNumber)
        {
            return regExNumber.IsMatch(phoneNumber);
        }
    }
}
