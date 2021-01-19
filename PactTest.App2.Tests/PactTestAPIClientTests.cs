using NUnit.Framework;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PactTest.App2.Tests
{
    [TestFixture]
    public class PactTestAPIClientTests
    {
        private PactTestApiPact _pactTestApiPact;

        private IMockProviderService _mockProviderService => _pactTestApiPact.MockProviderService;

        [OneTimeSetUp]
        public void configDependencies()
        {
            _pactTestApiPact = new PactTestApiPact();
            _pactTestApiPact.MockProviderService.ClearInteractions();
        }

        [OneTimeTearDown]
        public void releaseDependencies()
        {
            _pactTestApiPact.Dispose();
        }

        [Test]
        public void GetEventById_WhenTheEventWithIdExists_ReturnsTheEvent()
        {
            _mockProviderService
            .Given("There is a event in the event list with id of 1")
            .UponReceiving("A GET request to retrieve the event")
            .With(new ProviderServiceRequest
            {
                Method = HttpVerb.Get,
                Path = "/api/events/1",
                Headers = new Dictionary<string, object>
                {
                    { "Accept", "application/json" }
                }
            })
            .WillRespondWith(new ProviderServiceResponse
            {
                Status = 200,
                Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                Body = Match.Type(new
                {
                    id = 1,
                    description = "Event Description",
                    start = Match.Regex("01/06/2021", @"\d{2}\/\d{2}\/\d{4}"),
                    end = Match.Regex("10/06/2021", @"\d{2}\/\d{2}\/\d{4}"),
                    registrationStart = Match.Regex("01/05/2021", @"\d{2}\/\d{2}\/\d{4}"),
                    registrationEnd = Match.Regex("30/05/2021", @"\d{2}\/\d{2}\/\d{4}"),
                })
            });

            //Arrange
            var client = new PactTestAPIClient(_pactTestApiPact.MockProviderServerBaseUri);

            //Act
            var result = client.GetEvent(1);

            //Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Event Description", result.Description);
            Assert.AreEqual(new DateTime(2021, 06, 01), result.Start);
            Assert.AreEqual(new DateTime(2021, 06, 10), result.End);
            Assert.AreEqual(new DateTime(2021, 05, 01), result.RegistrationStart);
            Assert.AreEqual(new DateTime(2021, 05, 30), result.RegistrationEnd);
        }
    }
}
