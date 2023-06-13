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
    public class MedicalStaffService : IMedicalStaffService
    {
        private readonly IMapper mapper;
        private readonly IMedicalStaffRepository staffRepository;
        public MedicalStaffService(IMapper mapper, IMedicalStaffRepository staffRepository) { 
            this.mapper = mapper;
            this.staffRepository = staffRepository;
        }
        public async Task<MedicalStaff> AddMedicalStaffAsync(MedicalStaffDto staffDto)
        {
           
            var medicStaff = mapper.Map<MedicalStaff>(staffDto);
            medicStaff.ID = Guid.NewGuid();

            await staffRepository.AddMedicalStaff(medicStaff);

            return medicStaff;
        }

        public async Task DeleteMedicalStaffByIdAsync(Guid Id)
        {
            await staffRepository.DeleteMedicalStaffById(Id);
        }

        public async Task<List<MedicalStaff>?> GetMedicalStaffAsync()
        {
            var listOfStaff = await staffRepository.GetAllMedicalStaff();
            return listOfStaff;
        }
        public async Task<MedicalStaff?> GetMedicalStaffByIdAsync(Guid Id)
        {
            var staff = await staffRepository.GetMedicalStaffById(Id);

            return staff;
        }

        public async Task<List<MedicalStaff>?> GetMedicByNameAsync(string name)
        {
            var listOfStaffByName = await staffRepository.GetMedicalStaffByName(name);
            return listOfStaffByName;
        }

        public async Task<MedicalStaff?> UpdateMedicalStaffByIdAsync(MedicalStaffDto staffDto, Guid Id)
        {
            var staff = await staffRepository.GetMedicalStaffById(Id);
            if(staff == null)
            {
                throw new Exception("Medic not found");
            }
            var staffToUpdate = mapper.Map(staffDto, staff);
            await staffRepository.UpdateMedicalStaff(staffToUpdate);
           var staffReturnedAfter= await staffRepository.GetMedicalStaffById(Id);
            return staffReturnedAfter;
        }
    }
}
