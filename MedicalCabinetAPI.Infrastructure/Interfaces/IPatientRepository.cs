using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Interfaces
{
    public interface IPatientRepository
    {
        public Task AddPatient(Patient patient);
        public Task<List<Patient>?> GetPatientByName(string name);
        public Task<Patient?> GetPatientById(Guid Id);
        public Task<List<Patient>?> GetAllPatients();
        public Task UpdatePatient(Patient patient);
        public Task DeletePatientById(Guid id);
    }
}
