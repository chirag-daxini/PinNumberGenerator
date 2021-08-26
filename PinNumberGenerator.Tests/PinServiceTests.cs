using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinNumberGenerator.Domain.Services;
using PinNumberGenerator.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinNumberGenerator.Tests
{
    [TestClass]
    public class PinServiceTests
    {
        [TestInitialize]
        public void Intialize()
        {

        }
        [TestMethod]
        public async Task Should_Generate_Unique_Pin()
        {
            List<GenerateNewPinResponse> responses = new List<GenerateNewPinResponse>();
            for (int i = 0; i < 100; i++)
            {
                var pinService = new PinService();
                responses.Add(await pinService.GeneratePin());
            }

            var duplicates = responses
                .GroupBy(i => i.Pin)
                 .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            Assert.IsFalse(duplicates.Any());
        }
    }
}
