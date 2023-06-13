using AutoMapper;
using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using MedicalCabinetAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper mapper;
        private readonly IPatientRepository patientRepository;

        public PatientService(IMapper mapper, IPatientRepository patientRepository)
        {
            this.mapper = mapper;
            this.patientRepository = patientRepository;
        }

        public async Task<Patient> AddPatientAsync(PatientDto patientDto)
        {
            Console.WriteLine(patientDto.DateOfBirth);
            var patient = mapper.Map<Patient>(patientDto);
            patient.ID = Guid.NewGuid();
            Console.WriteLine(patient.DateOfBirth);
            await patientRepository.AddPatient(patient);

            return patient;
        }

        public async Task DeletePatientByIdAsync(Guid Id)
        {
            await patientRepository.DeletePatientById(Id);
        }

        public async Task<List<Patient>?> GetPatientAsync()
        {
            var listOfPatients = await patientRepository.GetAllPatients();
            return listOfPatients;
        }

        public async Task<List<Patient>?> GetPatientByNameAsync(string name)
        {
            var listOfPatientByName = await patientRepository.GetPatientByName(name);
            return listOfPatientByName;
        }
        public async Task<Patient> GetPatientByIdAsync(Guid Id)
        {
            var patient = await patientRepository.GetPatientById(Id);
            return patient;
        }

        public async Task<Patient?> UpdatePatientByIdAsync(Guid Id, PatientDto patientDto)
        {
            var patient = await patientRepository.GetPatientById(Id);
            if(patient == null)
            {
                throw new Exception("Patient not found");
            }
            var patientToUpdate = mapper.Map(patientDto, patient);
            await patientRepository.UpdatePatient(patientToUpdate);

            var patientReturnedAfter = await patientRepository.GetPatientById(Id);
            return patientReturnedAfter;
        }

    }
}
