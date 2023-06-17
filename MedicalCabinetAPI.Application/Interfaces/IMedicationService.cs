using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Interfaces
{
    public interface IMedicationService
    {
        public Task<Medication> AddMedicationAsync(MedicationDto medicationDto);
        public Task<List<Medication>?> GetMedicationByNameAsync(string name);
        public Task<Medication?> GetMedicationByIdAsync(Guid Id);
        public Task<List<Medication>?> GetMedicationsAsync();
        public Task<Medication?> UpdateMedicationByIdAsync(MedicationDto medicationDto, Guid Id);
        public Task DeleteMedicationByIdAsync(Guid Id);
    }
}
