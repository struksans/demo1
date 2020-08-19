using System;
using System.Net.Http;
using Moq;
using Moq.Contrib.HttpClient;

namespace QRCode.Service.Tests
{
    public abstract class TestsBase
    {
        protected TestFixture Fixture;

        protected TestsBase(TestFixture fixture)
        {
            Fixture = fixture;
        }

        //Should be more generic and live in separate project
        protected HttpClient MockHttpClient(string uri, string response)
        {
            var handler = new Mock<HttpMessageHandler>();
            var client = handler.CreateClient();

            handler.SetupRequest(HttpMethod.Post, uri)
                .ReturnsResponse(response, "application/json");

            return client;
        }

        //Should be more generic and live in separate project
        protected HttpClient MockHttpClientException(string uri)
        {
            var handler = new Mock<HttpMessageHandler>();
            var client = handler.CreateClient();

            handler.SetupRequest(HttpMethod.Post, uri)
                .Throws(new Exception("error"));

            return client;
        }
    }
}
