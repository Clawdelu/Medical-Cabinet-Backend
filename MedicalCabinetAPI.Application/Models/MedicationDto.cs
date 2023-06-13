using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Models
{
    public class MedicationDto
    {
        public string? Name { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid ID_medicalStaff { get; set; }
    }
}
