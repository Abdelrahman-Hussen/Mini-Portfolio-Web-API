using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Portfolio.Common.Enums;
using System.Text;

namespace Portfolio.Common.Helpers
{
    public static class ValidationHelper
    {
        public static string ArrangeValidationErrors(List<ValidationFailure> validationFailures)
        {
            StringBuilder errors = new StringBuilder();

            foreach (var error in validationFailures)
                errors.Append($"{error.PropertyName} : {error}\n");

            return errors.ToString();
        }

        public static string ArrangeIdentityErrors(IEnumerable<IdentityError> identityError)
        {
            var errors = new StringBuilder();

            foreach (var error in identityError)
                errors.Append($"{error.Description}\n");

            return errors.ToString();
        }

        public static bool IsValid(this TranslatableContent source)
        {
            int totalItems = Enum.GetNames(typeof(Language)).Length;

            bool hasAllLanguage = totalItems == source.Count;

            bool hasNoDuplicates = !source.GroupBy(obj => obj.Language)
                                            .Any(group => group.Count() > 1);

            return (hasAllLanguage && hasNoDuplicates);
        }
    }
}
