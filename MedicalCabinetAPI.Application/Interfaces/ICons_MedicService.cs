using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Interfaces
{
    public interface ICons_MedicService
    {
        public Task AddCons_MedicAsync(ConsultationDto consDto, Guid idCons);
        public Task<List<Cons_Medic>?> GetCons_MedicByIdConsultationAsync(Guid idConsultation);
        public  Task UpdateCons_Medic(List<Cons_Medic> listC_M);
        public Task DeleteCons_MedicByConsultationId(Guid consultationID);
    }
}
