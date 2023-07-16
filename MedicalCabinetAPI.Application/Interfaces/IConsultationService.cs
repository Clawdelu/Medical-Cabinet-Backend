using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Interfaces
{
    public interface IConsultationService
    {
        public Task<Consultation> AddConsultationAsync(ConsultationDto consultationDto);
        public Task<List<ConsultationRequestDto>?> GetConsultationByPatientIdAsync(Guid patientId);
        public Task<ConsultationRequestDto?> GetConsultationByIdAsync(Guid Id);
        public Task<List<ConsultationRequestDto>?> GetConsultationsAsync();
        public Task<Consultation?> UpdateConsultationByIdAsync(ConsultationUpdate consultationUpdate, Guid Id);
        public Task DeleteConsultationByIdAsync(Guid Id);

    }
}

