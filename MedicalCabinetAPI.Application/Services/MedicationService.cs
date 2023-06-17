using AutoMapper;
using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using MedicalCabinetAPI.Infrastructure.Interfaces;
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
        private readonly IMedicationRepository medicationRepository;
        public MedicationService(IMapper mapper, IMedicationRepository medicationRepository) {
        this.mapper = mapper;
        this.medicationRepository = medicationRepository;
        }

        public async Task<Medication> AddMedicationAsync(MedicationDto medicationDto)
        {
            var med = mapper.Map<Medication>(medicationDto);
            med.ID = Guid.NewGuid();
            await medicationRepository.AddMedication(med);

            return med;
        }

        public async Task DeleteMedicationByIdAsync(Guid Id)
        {
            await medicationRepository.DeleteMedicationById(Id);
        }

        public async Task<Medication?> GetMedicationByIdAsync(Guid Id)
        {
            var med = await medicationRepository.GetMedicationById(Id);
            return med;
        }

        public async Task<List<Medication>?> GetMedicationByNameAsync(string name)
        {
            var listOfMed = await medicationRepository.GetMedicationByName(name);
            return listOfMed;
        }

        public async Task<List<Medication>?> GetMedicationsAsync()
        {
            var listOfMed = await medicationRepository.GetAllMedications();
            return listOfMed;
        }

        public async Task<Medication?> UpdateMedicationByIdAsync(MedicationDto medicationDto, Guid Id)
        {
            var medication = await medicationRepository.GetMedicationById(Id);
            if(medication == null) { throw new Exception("Medication not found"); }
            var medToUpdate = mapper.Map(medicationDto,medication);
            await medicationRepository.UpdateMedication(medToUpdate);

            var medReturned = await medicationRepository.GetMedicationById(Id);

            return medReturned;
        }
    }
}
