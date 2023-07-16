using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Interfaces
{
    public interface IConsultationRepository
    {
        public Task AddConsultation(Consultation consultation);
        public Task<Consultation?> GetConsultationById(Guid id);
        public Task<List<Consultation>?> GetAllConsultation();
        public Task<List<Consultation>?> GetConsultationByPatientId(Guid patientId);
        public Task UpdateConsultation(Consultation consultation);
        public Task DeleteConsultationById(Guid id);
    }
}
