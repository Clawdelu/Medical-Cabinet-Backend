using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Interfaces
{
    public interface IMedicationRepository
    {
        public Task AddMedication(Medication medication);
        public Task<List<Medication>?> GetMedicationByName(string name);
        public Task<Medication?> GetMedicationById(Guid Id);
        public Task<List<Medication>?> GetAllMedications();
        public Task UpdateMedication(Medication medication);
        public Task DeleteMedicationById(Guid id);
    }
}
