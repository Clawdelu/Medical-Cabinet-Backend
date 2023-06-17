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
                    command.Parameters.Add("AvailableQuantity", OracleDbType.Int32).Value = medication.AvailableQuantity;
                    command.Parameters.Add("ExpirationDate", OracleDbType.Date).Value = medication.ExpirationDate;
                    command.Parameters.Add("ID_medicalStaff", OracleDbType.Raw).Value = medication.ID_medicalStaff;
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteMedicationById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.deleteMedication, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Medication>?> GetAllMedications()
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<Medication> medicationList = new List<Medication>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getAllMedications, connection))
                {

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                           // var idDate = reader.GetOrdinal("DateOfBirth");
                           // var idAvaiQ = reader.GetOrdinal("AvailableQuantity");
                            Medication med = new Medication
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                Name = reader["Name"].ToString(),
                                AvailableQuantity = reader.GetInt32(reader.GetOrdinal("AvailableQuantity")),
                                ExpirationDate = reader.IsDBNull(reader.GetOrdinal("ExpirationDate")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),                            
                                ID_medicalStaff = reader.GetGuid(reader.GetOrdinal("ID_medicalStaff"))
                            };

                            medicationList.Add(med);
                        }
                    }
                }
            }
            if (medicationList?.Count > 0)
            {
                return medicationList;
            }
            else
                return null;
        }

        public async Task<Medication?> GetMedicationById(Guid Id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getMedicationById, connection))
                {
                    command.Parameters.Add("medID", OracleDbType.Raw).Value = Id;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            Medication med = new Medication
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                Name = reader["Name"].ToString(),
                                AvailableQuantity = reader.GetInt32(reader.GetOrdinal("AvailableQuantity")),
                                ExpirationDate = reader.IsDBNull(reader.GetOrdinal("ExpirationDate")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                                ID_medicalStaff = reader.GetGuid(reader.GetOrdinal("ID_medicalStaff"))
                            };
                            return med;
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<Medication>?> GetMedicationByName(string name)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<Medication> medicationList = new List<Medication>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getMedicationByName, connection))
                {
                    command.Parameters.Add("Name", OracleDbType.NVarchar2).Value = name;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Medication med = new Medication
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                Name = reader["Name"].ToString(),
                                AvailableQuantity = reader.GetInt32(reader.GetOrdinal("AvailableQuantity")),
                                ExpirationDate = reader.IsDBNull(reader.GetOrdinal("ExpirationDate")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                                ID_medicalStaff = reader.GetGuid(reader.GetOrdinal("ID_medicalStaff"))
                            };

                            medicationList.Add(med);
                        }
                    }
                }
            }
            if (medicationList?.Count > 0)
            {
                return medicationList;
            }
            else
                return null;
        }

        public async Task UpdateMedication(Medication medication)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.updateMedication, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = medication.ID;
                    command.Parameters.Add("Name", OracleDbType.NVarchar2).Value = medication.Name;
                    command.Parameters.Add("AvailableQuantity", OracleDbType.Int32).Value = medication.AvailableQuantity;
                    command.Parameters.Add("ExpirationDate", OracleDbType.Date).Value = medication.ExpirationDate;
                    command.Parameters.Add("ID_medicalStaff", OracleDbType.Raw).Value = medication.ID_medicalStaff;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
