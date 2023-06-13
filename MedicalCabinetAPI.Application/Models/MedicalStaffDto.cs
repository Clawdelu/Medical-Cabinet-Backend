using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Models
{
    public class MedicalStaffDto
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Speciality { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
