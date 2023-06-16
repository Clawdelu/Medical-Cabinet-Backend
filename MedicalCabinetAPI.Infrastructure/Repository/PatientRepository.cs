using MedicalCabinetAPI.Domain.Entities;
using MedicalCabinetAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration configuration;
        public PatientRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task AddPatient(Patient patient) ///NU E GATA...QUERIES. TB FACUTA INTEROGAREA
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.insertPatient, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = patient.ID;
                    command.Parameters.Add("LastName", OracleDbType.NVarchar2).Value = patient.LastName;
                    command.Parameters.Add("FirstName", OracleDbType.NVarchar2).Value = patient.FirstName;
                    command.Parameters.Add("DateOfBirth", OracleDbType.Date).Value = patient.DateOfBirth;
                    command.Parameters.Add("Address", OracleDbType.NVarchar2).Value = patient.Address;
                    command.Parameters.Add("PhoneNumber", OracleDbType.NVarchar2).Value = patient.PhoneNumber;
                    command.Parameters.Add("ID_medicalStaff", OracleDbType.Raw).Value = patient.ID_medicalStaff;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeletePatientById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                //string query = "DELETE FROM \"PATIENT\" WHERE ID = :ID";

                using (OracleCommand command = new OracleCommand(Queries.deletePatient, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Patient>?> GetAllPatients()
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<Patient> patientList = new List<Patient>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getAllPatients, connection))
                {

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var idDate = reader.GetOrdinal("DateOfBirth");
                            
                            Patient patient = new Patient
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? new DateTime(1,1,1) : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                ID_medicalStaff = reader.GetGuid(reader.GetOrdinal("ID_medicalStaff"))                
                            };

                            patientList.Add(patient);
                        }
                    }
                }
            }
            if (patientList?.Count > 0)
            {
                return patientList;
            }
            else
                return null;
        }

        public async Task<Patient?> GetPatientById(Guid Id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
           
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getPatientById, connection))
                {
                    command.Parameters.Add("patientID", OracleDbType.Raw).Value = Id;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {                         
                            Patient patient = new Patient
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                ID_medicalStaff = reader.GetGuid(reader.GetOrdinal("ID_medicalStaff"))
                            };
                            return patient;
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<Patient>?> GetPatientByName(string name)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<Patient> patientListByName = new List<Patient>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getPatientByName, connection))
                {
                    command.Parameters.Add("FirstName", OracleDbType.NVarchar2).Value = name;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Patient patient = new Patient
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? new DateTime(1, 1, 1) : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                ID_medicalStaff = reader.GetGuid(reader.GetOrdinal("ID_medicalStaff"))
                            };

                            patientListByName.Add(patient);
                        }
                    }
                }
            }
            if (patientListByName?.Count > 0)
            {
                return patientListByName;
            }
            else
                return null;
        }

        public async Task UpdatePatient(Patient patient)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync(); 

                using (OracleCommand command = new OracleCommand(Queries.updatePatient, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = patient.ID;
                    command.Parameters.Add("LastName", OracleDbType.NVarchar2).Value = patient.LastName;
                    command.Parameters.Add("FirstName", OracleDbType.NVarchar2).Value = patient.FirstName;
                    command.Parameters.Add("DateOfBirth", OracleDbType.NVarchar2).Value = patient.DateOfBirth;
                    command.Parameters.Add("Address", OracleDbType.NVarchar2).Value = patient.Address;
                    command.Parameters.Add("PhoneNumber", OracleDbType.NVarchar2).Value = patient.PhoneNumber;
                    command.Parameters.Add("ID_medicalStaff", OracleDbType.Raw).Value = patient.ID_medicalStaff;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
