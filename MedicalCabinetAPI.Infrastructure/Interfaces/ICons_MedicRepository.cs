using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Interfaces
{
    public interface ICons_MedicRepository
    {
        public Task AddCons_Medic(Cons_Medic cons_medic);
        public Task<List<Cons_Medic>?> GetCons_MedicByIdConsultation(Guid idConsultation);
        public Task<Cons_Medic?> GetCons_MedicById(Guid id);
        // public Task<List<Consultation>?> GetCons_MedicByIdMedication(Guid idMedication);  OPTIONAL
        public Task UpdateCons_Medic(Cons_Medic cons_medic);    
        public Task DeleteCons_MedicById(Guid id);
    }
}
