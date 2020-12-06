using System;
using System.Collections.Generic;

namespace StaffAPI.Models
{
    public partial class Patients
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string HealthCardNumber { get; set; }
    }
}
