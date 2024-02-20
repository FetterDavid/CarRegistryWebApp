using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Attributes
{
    public class ValidRegistrationNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string licensePlate = value.ToString();
                if (IsValidRegistrationNumber(licensePlate))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The registration number format is invalid. Allowed formats: ABC-123 or ABC-12-34.", new[] { validationContext.MemberName });
                }
            }
            return ValidationResult.Success;
        }

        private bool IsValidRegistrationNumber(string licensePlate)
        {
            if (string.IsNullOrEmpty(licensePlate)) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(licensePlate.Trim().ToUpper(), @"^[A-Z]{3}-\d{3}$|^[A-Z]{3}-\d{2}-\d{2}$");
        }
    }
}
