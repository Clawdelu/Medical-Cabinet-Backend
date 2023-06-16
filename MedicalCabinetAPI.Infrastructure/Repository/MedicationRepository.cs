using MedicalCabinetAPI.Domain.Entities;
using MedicalCabinetAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Repository
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly IConfiguration configuration;

        public MedicationRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task AddMedication(Medication medication)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.insertMedication , connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = medication.ID;
                    command.Parameters.Add("Name", OracleDbType.NVarchar2).Value = medication.Name;
                    command.Parameters.Add("AvailableQuantity", OracleDbType.Int64).Value = medication.AvailableQuantity;
                    command.Parameters.Add("ExpirationDate", OracleDbType.Date).Value = medication.ExpirationDate;
                    command.Parameters.Add("ID_medicalStaff", OracleDbType.Raw).Value = medication.ID_medicalStaff;
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public Task DeleteMedicationById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Medication>?> GetAllMedications()
        {
            throw new NotImplementedException();
        }

        public Task<Medication?> GetMedicationById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Medication>?> GetMedicationByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMedication(Medication medication)
        {
            throw new NotImplementedException();
        }
    }
}
