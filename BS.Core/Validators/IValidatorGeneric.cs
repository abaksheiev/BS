﻿namespace BS.Contracts.PostAggregations.Validators
{
    public interface IValidator<T>
    {
        bool Validate(T entity, out List<string> errors);
    }
}
