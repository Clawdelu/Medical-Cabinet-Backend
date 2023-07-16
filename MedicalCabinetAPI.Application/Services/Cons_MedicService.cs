using AutoMapper;
using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using MedicalCabinetAPI.Infrastructure.Interfaces;
using MedicalCabinetAPI.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Services
{
    public class Cons_MedicService : ICons_MedicService
    {
        private readonly IMapper mapper;     
        private readonly ICons_MedicRepository cons_medicRepository;

        public Cons_MedicService(IMapper mapper, ICons_MedicRepository cons_medicRepository)
        {
            this.mapper = mapper;
            this.cons_medicRepository = cons_medicRepository;
        }
        public async Task AddCons_MedicAsync(ConsultationDto consDto, Guid idCons)
        {
            foreach (var item in consDto.ListConsMedic)
            {
                var cons_medic = mapper.Map<Cons_Medic>(item);
                cons_medic.ID = Guid.NewGuid();
                cons_medic.ID_consultation = idCons;
                await cons_medicRepository.AddCons_Medic(cons_medic);
            }
        }

        public async Task DeleteCons_MedicByConsultationId(Guid consultationID)
        {
            await cons_medicRepository.DeleteCons_MedicById(consultationID);
        }

        public async Task<List<Cons_Medic>?> GetCons_MedicByIdConsultationAsync(Guid idConsultation)
        {
            var cons_medic = await cons_medicRepository.GetCons_MedicByIdConsultation(idConsultation);
            return cons_medic;
        }

        public async Task UpdateCons_Medic(List<Cons_Medic> listC_M)
        {
            /*var cons_medic = await cons_medicRepository.GetCons_MedicByIdConsultation();
            var consToUpdate = mapper.Map(consultationDto, consultation);*/

            foreach (var item in listC_M)
            {
                var cons_medic = await cons_medicRepository.GetCons_MedicById(item.ID);
                if (cons_medic == null)
                {
                    throw new Exception("cons_medic not found");
                }
                //var consToUpdate = mapper.Map(item, cons_medic);
                var consToUpdate = item;
                await cons_medicRepository.UpdateCons_Medic(consToUpdate);

            }
                  
        }
    }
}
