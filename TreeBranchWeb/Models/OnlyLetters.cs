using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TreeBranchWeb.Models
{
    public class OnlyLetters : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (new Regex("[a-zA-Z]+").IsMatch((string) value))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("You may only use letters.");
        }
    }
}