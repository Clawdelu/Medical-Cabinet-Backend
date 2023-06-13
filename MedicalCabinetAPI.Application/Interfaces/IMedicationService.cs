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
        public Task<Medication> GetMedicationByName(string name);
        public Task<Medication> GetMedicationById(Guid Id);
        public Task<List<Medication>> GetMedicationsAsync();
        public Task UpdateMedicationById(MedicationDto medicationDto, Guid Id);
        public Task DeleteMedicationById(Guid Id);
    }
}
