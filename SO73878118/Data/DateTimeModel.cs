﻿using System.ComponentModel.DataAnnotations;

namespace SO73878118.Data
{
    public class DateTimeModel : IValidatableObject
    {
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ToDate < FromDate)
            {
                yield return new ValidationResult("ToDate must be after FromDate", new[] { nameof(ToDate) });
            }
        }
    }
}