using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using PactNet;
using PactNet.Infrastructure.Outputters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PactTest.API.Tests
{
    [TestFixture]
    public class PactTestApiTests : IDisposable
    {
        private string _providerUri { get; }
        private string _pactServiceUri { get; }
        private IWebHost _webHost { get; }

        public PactTestApiTests()
        {
            _providerUri = "http://localhost:5000";
            _pactServiceUri = "http://localhost:5002";

            _webHost = WebHost.CreateDefaultBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            _webHost.Start();
        }

        [Test]
        public void EnsurePactTestApiHonoursPactWithConsumerApp1()
        {
            var config = new PactVerifierConfig()
            {
                Outputters = new List<IOutput>
                {
                    new NUnitOutput()
                },
                Verbose = true,
                //PublishVerificationResults = true,
                ProviderVersion = "1.0.0-adasdas"
            };

            var pactVerifier = new PactVerifier(config);
            pactVerifier
                .ServiceProvider("PactTest.API", _providerUri)
                .HonoursPactWith("PactTest.App1")
                .PactUri(@"../../../../pacts/app1-pacttest.api.json")
                .Verify();
        }

        [Test]
        public void EnsurePactTestApiHonoursPactWithConsumerApp2()
        {
            var config = new PactVerifierConfig()
            {
                Outputters = new List<IOutput>
                {
                    new NUnitOutput()
                },
                Verbose = true,
                PublishVerificationResults = true,
                ProviderVersion = "1.0.0-adasdas"
            };

            var pactVerifier = new PactVerifier(config);
            pactVerifier
                .ServiceProvider("PactTest.API", _providerUri)
                .HonoursPactWith("PactTest.App2")
                .PactUri(@"../../../../pacts/app2-pacttest.api.json")
                .Verify();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _webHost.StopAsync().GetAwaiter().GetResult();
                    _webHost.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}
