using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FluentValidation.Attributes;
using FluentValidationSample.Validation;

namespace FluentValidationSample.Models
{
    [Validator(typeof(RegistrationModelValidator))]
    public class RegistrationModel
    {
        [DataType(DataType.Text)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
    }
}