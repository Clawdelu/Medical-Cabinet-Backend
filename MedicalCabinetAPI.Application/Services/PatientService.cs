using AutoMapper;
using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper mapper;

        public PatientService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<Patient> AddPatientAsync(PatientDto patientDto)
        {
            throw new NotImplementedException();
        }

        public Task DeletePatientByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetPatientAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetPatientByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public Task<Patient> GetPatientByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePatientByIdAsync(Guid Id, PatientDto patientDto)
        {
            throw new NotImplementedException();
        }
    }
}
