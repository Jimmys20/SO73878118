using System.ComponentModel.DataAnnotations;

namespace SO73878118.Data
{
    public class DateMustBeAfterAttribute : ValidationAttribute
    {
        public DateMustBeAfterAttribute(string propertyName)
            => PropertyName = propertyName;

        public string PropertyName { get; }

        public string GetErrorMessage(string valueName) =>
            $"'{valueName}' must be after '{PropertyName}'.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;

            if ((DateTime?)value < (DateTime?)model.GetType().GetProperty(PropertyName)?.GetValue(model, null))
            {
                var valueName = validationContext.MemberName ?? string.Empty;
                return new ValidationResult(GetErrorMessage(valueName), new[] { valueName });
            }

            return ValidationResult.Success;
        }
    }
}
