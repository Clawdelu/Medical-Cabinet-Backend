using MedicalCabinetAPI.Domain.Entities;
using MedicalCabinetAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Repository
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly IConfiguration configuration;
        public ConsultationRepository(IConfiguration configuration) { 
        this.configuration = configuration;
                }
        public async Task AddConsultation(Consultation consultation)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.insertConsultation, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = consultation.ID;
                    command.Parameters.Add("ID_Patient", OracleDbType.Raw).Value = consultation.ID_Patient;
                    command.Parameters.Add("ID_MedicalStaff", OracleDbType.Raw).Value = consultation.ID_MedicalStaff;
                    command.Parameters.Add("DateOfConsultation", OracleDbType.Date).Value = consultation.DateOfConsultation;
                    command.Parameters.Add("Symptoms", OracleDbType.NVarchar2).Value = consultation.Symptoms;
                    command.Parameters.Add("Diagnosis", OracleDbType.NVarchar2).Value = consultation.Diagnosis;

                    await command.ExecuteNonQueryAsync();
                }            
            }
        }

        public async Task DeleteConsultationById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.deleteConsultation, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Consultation>?> GetAllConsultation()
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<Consultation> consultationList = new List<Consultation>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getAllConsultation, connection))
                {

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Consultation consultation = new Consultation
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                ID_Patient = reader.GetGuid(reader.GetOrdinal("ID_Patient")),
                                ID_MedicalStaff = reader.GetGuid(reader.GetOrdinal("ID_MedicalStaff")),
                                DateOfConsultation = reader.IsDBNull(reader.GetOrdinal("DateOfConsultation")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("DateOfConsultation")),
                                Symptoms = reader["Symptoms"].ToString(),
                                Diagnosis = reader["Diagnosis"].ToString(),                              
                            };

                            consultationList.Add(consultation);
                        }
                    }
                }
            }
            if (consultationList?.Count > 0)
            {
                return consultationList;
            }
            else
                return null;
        }

        public async Task<Consultation?> GetConsultationById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getConsultationById, connection))
                {
                    command.Parameters.Add("consID", OracleDbType.Raw).Value = id;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            Consultation consultation = new Consultation
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                ID_Patient = reader.GetGuid(reader.GetOrdinal("ID_Patient")),
                                ID_MedicalStaff = reader.GetGuid(reader.GetOrdinal("ID_MedicalStaff")),
                                DateOfConsultation = reader.IsDBNull(reader.GetOrdinal("DateOfConsultation")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("DateOfConsultation")),
                                Symptoms = reader["Symptoms"].ToString(),
                                Diagnosis = reader["Diagnosis"].ToString(),
                            };
                            return consultation;
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<Consultation>?> GetConsultationByPatientId(Guid patientId)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<Consultation> consultationList = new List<Consultation>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getConsultationByPatientId, connection))
                {
                    command.Parameters.Add("patientID", OracleDbType.Raw).Value = patientId;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Consultation consultation = new Consultation
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                ID_Patient = reader.GetGuid(reader.GetOrdinal("ID_Patient")),
                                ID_MedicalStaff = reader.GetGuid(reader.GetOrdinal("ID_MedicalStaff")),
                                DateOfConsultation = reader.IsDBNull(reader.GetOrdinal("DateOfConsultation")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("DateOfConsultation")),
                                Symptoms = reader["Symptoms"].ToString(),
                                Diagnosis = reader["Diagnosis"].ToString(),
                            };

                            consultationList.Add(consultation);
                        }
                    }
                }
            }
            if (consultationList?.Count > 0)
            {
                return consultationList;
            }
            else
                return null;
        }

        public async Task UpdateConsultation(Consultation consultation)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.updateConsultation, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = consultation.ID;
                    command.Parameters.Add("ID_Patient", OracleDbType.Raw).Value = consultation.ID_Patient;
                    command.Parameters.Add("ID_MedicalStaff", OracleDbType.Raw).Value = consultation.ID_MedicalStaff;
                    command.Parameters.Add("DateOfConsultation", OracleDbType.Date).Value = consultation.DateOfConsultation;
                    command.Parameters.Add("Symptoms", OracleDbType.NVarchar2).Value = consultation.Symptoms;
                    command.Parameters.Add("Diagnosis", OracleDbType.NVarchar2).Value = consultation.Diagnosis;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
