
using MedicalCabinetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Interfaces
{
    public interface IMedicalStaffRepository
    {
        public Task AddMedicalStaff(MedicalStaff staff);
        public Task<MedicalStaff?> GetMedicalStaffById(Guid id);
        public Task<List<MedicalStaff>?> GetAllMedicalStaff();
        public Task<MedicalStaff?> GetMedicalStaffByName(string name);
        public Task UpdateMedicalStaff(MedicalStaff staff);
        public Task DeleteMedicalStaffById(Guid id);
    }
}
