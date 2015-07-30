using FluentValidation;
using FluentValidationSample.Models;

namespace FluentValidationSample.Validation
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty()
                .Length(1, 25);

            RuleFor(r => r.LastName)
                .NotEmpty()
                .Length(1, 25);

            RuleFor(r => r.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .SetValidator(new MustBeFromDomainEmailValidator("stormid.com"));

            RuleFor(r => r.DateOfBirth)
                .NotEmpty()
                .SetValidator(new AgeValidator(18));
        }
    }
}