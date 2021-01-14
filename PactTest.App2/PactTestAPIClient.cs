using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace PactTest.App2
{
    public class PactTestAPIClient
    {
        private readonly HttpClient _client;

        public PactTestAPIClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://localhost:5001") };
        }

        public Event GetEvent(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/events/{id}");
            request.Headers.Add("Accept", "application/json");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var statusCode = response.Result.StatusCode;

            var reasonPhrase = response.Result
                .ReasonPhrase;

            request.Dispose();
            response.Dispose();

            if (statusCode == HttpStatusCode.OK)
            {
                return !string.IsNullOrEmpty(content)
                    ? JsonConvert.DeserializeObject<Event>(content, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    })
                    : null;
            }

            throw new Exception(reasonPhrase);
        }
    }
}
