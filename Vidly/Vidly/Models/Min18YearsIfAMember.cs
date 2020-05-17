using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId==MembershipType.Unknown //0
                ||customer.MembershipTypeId == MembershipType.PayAsYouGo)//1
                //don't display birthday required if he didn't select membership type or selected pay as you go (1)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate==null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18 years old "); 
        }
    }
}