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
    public class MedicationService : IMedicationService
    {
        private readonly IMapper mapper;
        public MedicationService(IMapper mapper) {
        this.mapper = mapper;
        }

        public Task<Medication> AddMedicationAsync(MedicationDto medicationDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMedicationById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Medication> GetMedicationById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Medication> GetMedicationByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Medication>> GetMedicationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMedicationById(MedicationDto medicationDto, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
