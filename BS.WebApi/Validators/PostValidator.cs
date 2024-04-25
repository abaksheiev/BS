using BS.WebApi.Models;

namespace BS.WebApi.Validators
{
    public class PostValidator : IValidator<PostModel>
    {
        public bool Validate(PostModel entity, out List<string> errors)
        {
            errors = [];

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

            return errors.Any(); // All validation passed
        }
    }
}
