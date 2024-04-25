using BS.Contracts.ApiDtos;

namespace BS.Contracts.PostAggregations.Validators
{
    public class AuthorApiDtoValidator : IValidator<AuthorApiDto>
    {
        public bool Validate(AuthorApiDto entity, out List<string> errors)
        {
            errors = [];
            if (entity == null)
            {
                errors.Add($"Validation failed: {nameof(entity)} is null.");
                return errors.Any();
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                errors.Add($"Validation failed: {nameof(entity.Name)} is required.");
            }

            if (string.IsNullOrWhiteSpace(entity.Surname))
            {
                errors.Add($"Validation failed: {nameof(entity.Surname)} is required.");
            }

            return errors.Any();
        }
    }
}
