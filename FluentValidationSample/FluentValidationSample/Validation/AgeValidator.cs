using System;
using FluentValidation.Validators;
using FluentValidationSample.Extensions;

namespace FluentValidationSample.Validation
{
    public class AgeValidator : PropertyValidator
    {
        private readonly int _expectedAge;

        public AgeValidator(int expectedAge) : base("You must be at least {ExpectedAge} years old, you are only {Age} at {ComparisonDate}")
        {
            _expectedAge = expectedAge;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var dt = (DateTime)context.PropertyValue;
            var age = dt.AgeAt();

            context.MessageFormatter.AppendArgument("ExpectedAge", _expectedAge);
            context.MessageFormatter.AppendArgument("Age", age);
            context.MessageFormatter.AppendArgument("ComparisonDate", DateTime.UtcNow.Date);
            return age >= _expectedAge;

        }
    }
}