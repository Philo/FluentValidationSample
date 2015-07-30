using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace FluentValidationSample.Validation
{
    public class MustBeFromDomainEmailValidator : PropertyValidator
    {
        private readonly string _emailDomain;
        private static Regex _regex;


        public MustBeFromDomainEmailValidator(string emailDomain) : base("Your email address must be for the domain '{EmailDomain}'")
        {
            _emailDomain = emailDomain;
            _regex = new Regex(string.Format("^(.*)@{0}$", _emailDomain), RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return false;
            var email = context.PropertyValue.ToString();

            context.MessageFormatter.AppendArgument("EmailDomain", _emailDomain);
            return _regex.IsMatch(email);
        }
    }
}