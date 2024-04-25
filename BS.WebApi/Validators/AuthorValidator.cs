using BS.WebApi.Models;

namespace BS.WebApi.Validators
{
    public class AuthorValidator : IValidator<AuthorModel>
    {
        public bool Validate(AuthorModel entity, out List<string> errors)
        {
            errors = [];

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
