using System.ComponentModel.DataAnnotations;

namespace SO73878118.Data
{
    public class DateTimeModel //: IValidatableObject
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [DateMustBeBefore(nameof(ToDate))]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }

        [Required]
        [DateMustBeAfter(nameof(FromDate))]
        [DataType(DataType.Date)]     
        public DateTime? ToDate { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (ToDate < FromDate)
        //    {
        //        yield return new ValidationResult("ToDate must be after FromDate", new[] { nameof(ToDate) });
        //    }
        //}
    }
}
