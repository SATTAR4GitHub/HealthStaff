/**
 * Author: Abdus Sattar Mia
 * Date: Dec 05, 2020
 */

using Staff.CustomFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Staff.Models
{
    public class Patient
    {
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinimumAge(18, ErrorMessage = "You must be 18 years old.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [Required]
        [Display(Name = "Health Card")]
        public string HealthCardNumber { get; set; }
    }
}
