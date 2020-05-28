using AcmeLandingFinal.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeLandingFinal.Models
{
    public class Form
    {
        public int FormId { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [DateMinimumAge(18, ErrorMessage = "{0} must be of someone at least {1} years of age")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0}:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfBirth { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }


        [Required]
        [Display(Name = "Product serial number")]
        public string ProductSerialNumber { get; set; }
    }
}
