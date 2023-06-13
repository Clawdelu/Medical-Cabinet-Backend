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
        public Task<Consultation> AddConsultationAsync(ConsultationDto consultation);
        public Task<Consultation> GetConsultationByNameAsync(string name);
        public Task<Consultation> GetConsultationByIdAsync(Guid Id);
        public Task<List<Consultation>> GetConsultationAsync();
        public Task UpdateConsultationByIdAsync(ConsultationDto consultation, Guid Id);
        public Task DeleteConsultationByIdAsync(Guid Id);

    }
}
