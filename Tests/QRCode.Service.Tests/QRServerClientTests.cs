using System;
using System.IO;
using System.Net.Http;
using FluentAssertions;
using Moq;
using Moq.Contrib.HttpClient;
using QRCode.Common.Configs;
using QRCode.Common.Enums;
using Xunit;

namespace QRCode.Service.Tests
{
    [Collection("UnitTestCollection")]
    public class QRServerClientTests : TestsBase
    {
        public QRServerClientTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async void ScanAsync_Success()
        {
            var expected = await File.ReadAllTextAsync(@"Data/post_response_success.json");
            var client = MockHttpClient(Config.BaseUrl, expected);
            var target = new QRServerClient(client);
            var data = await target.ScanAsync(new byte[1]);

            data.Status.Should().Be(OperationStatus.Success);
            data.Result.Should().Be("Content of the read QR code");
        }

        [Fact]
        public async void ScanAsync_Fail()
        {
            var expected = await File.ReadAllTextAsync(@"Data/post_response_fail.json");
            var client = MockHttpClient(Config.BaseUrl, expected);
            var target = new QRServerClient(client);
            var actual = await target.ScanAsync(new byte[1]);

            actual.Status.Should().Be(OperationStatus.UnableToProcessImage);
            actual.Result.Should().BeNull();
        }

        [Fact]
        public async void ScanAsync_ThrowsException()
        {
            var client = MockHttpClientException(Config.BaseUrl);
            var target = new QRServerClient(client);
            var actual = await target.ScanAsync(new byte[1]);

            actual.Status.Should().Be(OperationStatus.ExternalApiError);
            actual.Result.Should().BeNull();
        }
    }
}
