using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Interfaces
{
    public interface IPatientService
    {
        public Task<Patient> AddPatientAsync(PatientDto patientDto);
        public Task<List<Patient>?> GetPatientByNameAsync(string name);
        public Task<Patient?> GetPatientByIdAsync(Guid Id);
        public Task<List<Patient>?> GetPatientAsync();
        public Task<Patient?> UpdatePatientByIdAsync(Guid Id, PatientDto patientDto);
        public Task DeletePatientByIdAsync(Guid Id);
    }
}
