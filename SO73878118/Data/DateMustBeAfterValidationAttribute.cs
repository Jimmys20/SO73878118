using System.ComponentModel.DataAnnotations;

namespace SO73878118.Data
{
    public class DateMustBeAfterAttribute : ValidationAttribute
    {
        public DateMustBeAfterAttribute(string propertyName)
            => PropertyName = propertyName;

        public string PropertyName { get; }

        public string GetErrorMessage() =>
            $"Date must be after {PropertyName}.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var model = (DateTimeModel)validationContext.ObjectInstance;

            if ((DateTime?)value < (DateTime?)model.GetType().GetProperty(PropertyName)?.GetValue(model, null))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
