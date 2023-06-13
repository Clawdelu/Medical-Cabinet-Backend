using AutoMapper;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            CreateMap<PatientDto, Patient>();
            /* CreateMap<PatientDto, Patient>()
             .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.ParseExact(src.DateOfBirth,"dd-MM-yyyy", CultureInfo.InvariantCulture)))
             .ForMember(dest => dest.ID_medicalStaff, opt => opt.MapFrom(src => Guid.Parse(src.ID_medicalStaff)));
            */
            CreateMap<Medication, MedicationDto>();
            CreateMap<Consultation, ConsultationDto>();

        }
    }
}
