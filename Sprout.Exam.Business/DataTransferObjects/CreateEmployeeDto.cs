using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sprout.Exam.Business.DataTransferObjects
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [MinLength(1, ErrorMessage = "Full Name must not be an empty string.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Tin must be at most 12 characters long.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Tin must consist of numbers only.")]
        public string Tin { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "The TypeId must be either 1 or 2.")]
        public int TypeId { get; set; }
    }
}
