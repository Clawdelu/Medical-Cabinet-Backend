using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Models
{
    public class Cons_MedicDto
    {
        public Guid ID_medication { get; set; }
        public int PrescribedDoseMedication { get; set; }
        public int PeriodOfTreatment { get; set; }
    }
}
