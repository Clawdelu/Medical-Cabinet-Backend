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
    public class ConsultationService : IConsultationService
    {
        private readonly IMapper mapper;

        public ConsultationService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<Consultation> AddConsultationAsync(ConsultationDto consultation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConsultationByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Consultation>> GetConsultationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Consultation> GetConsultationByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Consultation> GetConsultationByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateConsultationByIdAsync(ConsultationDto consultation, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
