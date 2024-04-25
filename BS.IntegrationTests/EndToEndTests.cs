using BS.Contracts.ApiDtos;
using BS.Init;
using BS.EndToEnd.Features;
using BS.EndToEnd.Utils;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BS.EndToEnd
{
    public class EndToEndTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private const string ApiPath = "/api/v1/posts";

        private readonly WebApplicationFactory<Startup> _factory;

        private readonly HttpClient _httpClient;

        public EndToEndTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task WhenPostDoesNotExist_ShouldBeReturnNotFound()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{ApiPath}/{Guid.NewGuid()}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task WhenPostWithAuthor_ShouldBeReturnOk()
        {
            var mockData = PostFeatures.GetItem();
            mockData.Author = AuthorFeatures.GetItem();

            HttpResponseMessage response = await _httpClient.PostAsync($"{ApiPath}/", mockData.ToStringContent());
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenPostWithoutAuthor_ShouldBeReturnOk()
        {
            var mockData = PostFeatures.GetItem();
            HttpResponseMessage response = await _httpClient.PostAsync($"{ApiPath}/", mockData.ToStringContent());

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenPostInvalidedModel_ShouldBeReturnBadRequest()
        {
            var mockData = PostFeatures.GetItem();
            mockData.Title = string.Empty;
            HttpResponseMessage response = await _httpClient.PostAsync($"{ApiPath}/", mockData.ToStringContent());

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("?ai=true", true)]
        [InlineData("?ai=false",false)]
        public async Task WhenAiPassed_ThenAuthorShouldBePresentOrNotBasedOnValue(string aiParam, bool isAuthorNotNull)
        {
            // Create Post With Author
            var mockData = PostFeatures.GetItem();
            mockData.Author = AuthorFeatures.GetItem();
            var response = await _httpClient.PostAsync($"{ApiPath}/", mockData.ToStringContent());
            string responseBody = await response.Content.ReadAsStringAsync();
            PostApiDto postApiDto = responseBody.FromJson<PostApiDto>();

            // Act
            HttpResponseMessage postResponse = await _httpClient.GetAsync($"{ApiPath}/{postApiDto.Id}{aiParam}");

            var postApiDtoContent = await postResponse.Content.ReadAsStringAsync();
            var postApiDtoInstance = postApiDtoContent.FromJson<PostApiDto>();
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _ = (isAuthorNotNull ? postApiDtoInstance.Author.Should().NotBeNull() : postApiDtoInstance.Author.Should().BeNull());
        }
    }
}
