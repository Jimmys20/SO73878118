using System.ComponentModel.DataAnnotations;

namespace SO73878118.Data
{
    public class DateMustBeBeforeAttribute : ValidationAttribute
    {
        public DateMustBeBeforeAttribute(string propertyName)
            => PropertyName = propertyName;

        public string PropertyName { get; }

        public string GetErrorMessage(string valueName) =>
            $"'{valueName}' must be before '{PropertyName}'.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var model = (DateTimeModel)validationContext.ObjectInstance;

            if ((DateTime?)value > (DateTime?)model.GetType().GetProperty(PropertyName)?.GetValue(model, null))
            {
                var valueName = validationContext.MemberName ?? string.Empty;
                return new ValidationResult(GetErrorMessage(valueName), new[] { valueName });
            }

            return ValidationResult.Success;
        }
    }
}
