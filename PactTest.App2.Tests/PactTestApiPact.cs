using PactNet;
using PactNet.Mocks.MockHttpService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PactTest.App2.Tests
{
    public class PactTestApiPact : IDisposable
    {
        private const string ConsumerName = "App2";
        private const string ProviderName = "PactTest.API";

        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort => 9311;
        public string MockProviderServerBaseUri => $"http://localhost:{MockServerPort}";

        public PactTestApiPact()
        {
            PactBuilder = new PactBuilder(new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"../../../../pacts",
                LogDir = @"../../../../pactsLogs"
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
