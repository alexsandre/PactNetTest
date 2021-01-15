using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using PactTest.App1;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using PactNet.Matchers;

namespace PactTest.App1.Tests
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
                    image = "Event image url"
                })
            });

            //Arrange
            var client = new PactTestAPIClient(_pactTestApiPact.MockProviderServerBaseUri);

            //Act
            var result = client.GetEvent(1);

            //Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Event Description", result.Description);
            Assert.AreEqual("Event image url", result.Image);
        }
    }
}
