using BS.Contracts.ApiDtos;

namespace BS.Contracts.PostAggregations.Validators
{
    public class PostApiDtoValidator(IValidator<AuthorApiDto> _authorValidator) : IValidator<PostApiDto>
    {
      
        public bool Validate(PostApiDto entity, out List<string> errors)
        {
            errors = [];

            if (entity == null)
            {
                errors.Add($"Validation failed: {nameof(entity)} is null.");
                return errors.Any();
            }

            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                errors.Add($"Validation failed: {nameof(entity.Title)} is required.");
            }

            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                errors.Add($"Validation failed: {nameof(entity.Description)} is required.");
            }

            if (string.IsNullOrWhiteSpace(entity.Content))
            {
                errors.Add($"Validation failed: {nameof(entity.Content)} is required.");
            }

            // Validate Author entity
            if (entity.Author != null) {

                _authorValidator.Validate(entity.Author, out errors);
            }

            return errors.Any(); // All validation passed
        }
    }
}
