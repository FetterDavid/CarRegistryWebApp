using System.ComponentModel.DataAnnotations;

namespace Model.Attributes
{
    class LaterThanAttribute : ValidationAttribute
    {
        private readonly DateTime _earliestDate;

        public LaterThanAttribute(string earliestDate)
        {
            if (!DateTime.TryParse(earliestDate, out _earliestDate))
            {
                throw new ArgumentException("Invalid date format in attribute parameter. Please provide a valid date.");
            }
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date > DateTime.Now) return new ValidationResult($"The date cannot be in the future", new[] { validationContext.MemberName });
                if (date < _earliestDate) return new ValidationResult($"The date must be later than {_earliestDate.ToString("yyyy-MM-dd")}", new[] { validationContext.MemberName });
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid date format. Please provide a valid date.", new[] { validationContext.MemberName });
        }
    }

}
