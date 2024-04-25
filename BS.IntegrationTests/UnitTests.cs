
using BS.Contracts.ApiDtos;
using BS.Contracts.PostAggregations.Validators;
using FluentAssertions;
using Moq;

namespace BS.IntegrationTests
{
    public class UnitTests
    {
        Mock<IValidator<AuthorApiDto>> _authorValidatorMock= new Mock<IValidator<AuthorApiDto>>();


        [Fact]
        public async Task WhenPostDoesNotHaveAllProperties_ValidatorShouldReturnErrors()
        {
            // Create empty model
            var item = new PostApiDto();
            List<string> errorsOutput;

            _authorValidatorMock.Setup(o => o.Validate(It.IsAny<AuthorApiDto>(), out errorsOutput)).Returns(false);

            // Validate invalid model
            var validator = new PostApiDtoValidator(_authorValidatorMock.Object);
            var result = validator.Validate(item, out List<string> errorsOutputList);

            // Asserts
            result.Should().BeTrue();
            errorsOutputList.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task WhenAuthorDoesNotHaveAllProperties_ValidatorShouldReturnErrors()
        {
            // Create empty model
            var item = new AuthorApiDto();
         
            // Validate invalid model
            var validator = new AuthorApiDtoValidator();
            var result = validator.Validate(item, out List<string> errorsOutputList);

            // Asserts
            result.Should().BeTrue();
            errorsOutputList.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task WhenAuthorIsNull_ValidatorShouldReturnErrors()
        {
            // Validate invalid model
            var validator = new AuthorApiDtoValidator();
            var result = validator.Validate(null, out List<string> errorsOutputList);

            // Asserts
            result.Should().BeTrue();
            errorsOutputList.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task WhenPostIsNull_ValidatorShouldReturnErrors()
        {
            // Validate invalid model
            var validator = new PostApiDtoValidator(_authorValidatorMock.Object);
            var result = validator.Validate(null, out List<string> errorsOutputList);

            // Asserts
            result.Should().BeTrue();
            errorsOutputList.Count.Should().BeGreaterThan(0);
        }
    }
}
