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
    public class ConsultationService : IConsultationService
    {
        private readonly IMapper mapper;
        private readonly IConsultationRepository consultationRepository;
        private readonly ICons_MedicService cons_medicService;

        public ConsultationService(IMapper mapper, IConsultationRepository consultationRepository, ICons_MedicService cons_medicService)
        {
            this.mapper = mapper;
            this.consultationRepository = consultationRepository;
            this.cons_medicService = cons_medicService;
        }

        public async Task<Consultation> AddConsultationAsync(ConsultationDto consultationDto)
        {
            var consultation = mapper.Map<Consultation>(consultationDto);
            consultation.ID = Guid.NewGuid();
            await consultationRepository.AddConsultation(consultation);

            await cons_medicService.AddCons_MedicAsync(consultationDto, consultation.ID);

            return consultation;
        }

        public async Task DeleteConsultationByIdAsync(Guid Id)
        {
            await consultationRepository.DeleteConsultationById(Id);

            await cons_medicService.DeleteCons_MedicByConsultationId(Id);

        }

        public async Task<List<ConsultationRequestDto>?> GetConsultationsAsync()
        {
            var listOfConsultations = await consultationRepository.GetAllConsultation();
            List<ConsultationRequestDto> listOfRequest = new List<ConsultationRequestDto>();
            List<Cons_Medic> list = new List<Cons_Medic>();
            foreach (var consultation in listOfConsultations)
            {
                list.Clear();
                var consDto = mapper.Map<ConsultationRequestDto>(consultation);
                var listOfcons_me = await cons_medicService.GetCons_MedicByIdConsultationAsync(consultation.ID);
                
               
                consDto.ListOfCons_Medic = listOfcons_me;
                listOfRequest.Add(consDto);
            }

            return listOfRequest;
        }

        public async Task<ConsultationRequestDto?> GetConsultationByIdAsync(Guid Id)
        {
            //List<Cons_Medic> list = new List<Cons_Medic>();
            var consultation = await consultationRepository.GetConsultationById(Id);
            var consDto = mapper.Map<ConsultationRequestDto>(consultation);
            var listOfcons_me = await cons_medicService.GetCons_MedicByIdConsultationAsync(Id);
           /* foreach (var item in listOfcons_me)
            {
                list.Add(item);
                
            }*/
            consDto.ListOfCons_Medic = listOfcons_me;

            return consDto;
        }

        public async Task<List<ConsultationRequestDto>?> GetConsultationByPatientIdAsync(Guid patientId)
        {
            var listOfConsultationsByPatient = await consultationRepository.GetConsultationByPatientId(patientId);
            List<ConsultationRequestDto> listOfRequest = new List<ConsultationRequestDto>();
            foreach (var consultation in listOfConsultationsByPatient)
            {
                var consDto = mapper.Map<ConsultationRequestDto>(consultation);
                var listOfcons_me = await cons_medicService.GetCons_MedicByIdConsultationAsync(consultation.ID);
                consDto.ListOfCons_Medic = listOfcons_me;
                /* foreach (var item in listOfcons_me)
                 {
                     consDto.ListOfCons_Medic.Add(item);
                 }*/
                listOfRequest.Add(consDto);
            }

            return listOfRequest;
        }

        public async Task<Consultation?> UpdateConsultationByIdAsync(ConsultationUpdate consultationUpdate, Guid Id)
        {
            var consultation = await consultationRepository.GetConsultationById(Id);
            if (consultation == null)
            
                {
                    throw new Exception("Patient not found");
                }
                var consToUpdate = mapper.Map(consultationUpdate, consultation);
                await consultationRepository.UpdateConsultation(consToUpdate);
                await cons_medicService.UpdateCons_Medic(consultationUpdate.ListConsMedic);

                var consReturnedAfter = await consultationRepository.GetConsultationById(Id);
                return consReturnedAfter;
            
        }
    }
}
