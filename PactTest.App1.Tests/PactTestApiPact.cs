using PactNet;
using PactNet.Mocks.MockHttpService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PactTest.App1.Tests
{
    public class PactTestApiPact : IDisposable
    {
        private const string ConsumerName = "App1";
        private const string ProviderName = "PactTest.API";

        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort => 9310;
        public string MockProviderServerBaseUri => $"http://localhost:{MockServerPort}";

        public PactTestApiPact()
        {
            PactBuilder = new PactBuilder(new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"../../../../pacts"
            });

            PactBuilder
                .ServiceConsumer(ConsumerName)
                .HasPactWith(ProviderName);

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}
