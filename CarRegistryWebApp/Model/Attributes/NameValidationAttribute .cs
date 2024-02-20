using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Attributes
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string name = (string)value;

            if (string.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult("Name can t be empty", new[] { validationContext.MemberName });
            }

            // Különleges karakterek ellenõrzése
            if (name.IndexOfAny("^[^!?_-:;#]+$".ToCharArray()) != -1)
            {
                return new ValidationResult("Invalid character in the name.", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
