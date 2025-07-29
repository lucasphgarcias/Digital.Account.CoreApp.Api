using FluentValidation.Results;

namespace WebApi.Models.Error
{
    public static class ValidatorErroExtension
    {
        public static object ToCustomValidatorFailure(this IEnumerable<ValidationFailure> errors)
        {
            return new
            {
                Errors = errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            };
        }
    }
}
