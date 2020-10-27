using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myvidly.Models
{
    public class stockQTY: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (movie)validationContext.ObjectInstance;
            if (movie.Stock == 0 || movie.Stock > 20)
                return new ValidationResult("The quantity should be between 1 and 20");
            else
                return ValidationResult.Success;
        }
    }
}