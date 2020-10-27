using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace myvidly.Models
{
    public class minAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (customer)validationContext.ObjectInstance;
            if (customer.membershipTypeId == 1 || customer.membershipTypeId==0)
                return ValidationResult.Success;
            if (customer.BirthData == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.BirthData.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                :new ValidationResult("customer should be at leaset 18 to go with membership");
        }
    }
}