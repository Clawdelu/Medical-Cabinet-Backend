using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Application.Interfaces
{
    public interface IMedicalStaffService
    {
        public Task<MedicalStaff> AddMedicalStaffAsync(MedicalStaffDto staff);
        public Task<MedicalStaff?> GetMedicByNameAsync(string name);
        public Task<MedicalStaff?> GetMedicalStaffByIdAsync(Guid Id);
        public Task<List<MedicalStaff>?> GetMedicalStaffAsync();
        public Task<MedicalStaff> UpdateMedicalStaffByIdAsync(MedicalStaffDto staffDto, Guid Id);
        public Task DeleteMedicalStaffByIdAsync(Guid Id);

    }
}
