using BS.IntegrationTests.Core;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace BS.IntegrationTests
{

    public class MyIntegrationTests : IClassFixture<WebApplicationFactory<StartupContext>>
    {
        private const string ApiPath = "/api/v1/posts";

        private readonly WebApplicationFactory<StartupContext> _factory;

        private readonly HttpClient _httpClient;

        public MyIntegrationTests(WebApplicationFactory<StartupContext> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            // Act
            HttpResponseMessage response = await _httpClient.GetAsync($"{ApiPath}/3");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
