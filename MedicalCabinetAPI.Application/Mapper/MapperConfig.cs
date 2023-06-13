using AutoMapper;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;


namespace MedicalCabinetAPI.Application.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {

            CreateMap<MedicalStaff, MedicalStaffDto>();
            CreateMap<MedicalStaffDto, MedicalStaff>();
            CreateMap<Patient, PatientDto>();
            CreateMap<Medication, MedicationDto>();
            CreateMap<Consultation, ConsultationDto>();

        }
    }
}
