using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sprout.Exam.Business.DataTransferObjects
{
    public abstract class BaseSaveEmployeeDto
    {
        [MinLength(1, ErrorMessage = "FullName must not be an empty string.")]
        public string FullName { get; set; }

        [StringLength(12, ErrorMessage = "Full Name must be at most 12 characters long.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Tin must consist of numbers only.")]
        public string Tin { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Range(1, 2, ErrorMessage = "The TypeId must be either 1 or 2.")]
        public int TypeId { get; set; }
    }
}
