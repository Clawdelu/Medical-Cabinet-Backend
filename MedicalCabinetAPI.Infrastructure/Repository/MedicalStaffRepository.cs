using AutoMapper.Internal;
using MedicalCabinetAPI.Domain.Entities;
using MedicalCabinetAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure.Repository
{
    public class MedicalStaffRepository : IMedicalStaffRepository
    {
        private readonly IConfiguration configuration;

        public MedicalStaffRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task AddMedicalStaff(MedicalStaff staff)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.createMedicalStaff, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = staff.ID;
                    command.Parameters.Add("LastName", OracleDbType.NVarchar2).Value = staff.LastName;
                    command.Parameters.Add("FirstName", OracleDbType.NVarchar2).Value = staff.FirstName;
                    command.Parameters.Add("Speciality", OracleDbType.NVarchar2).Value = staff.Speciality;
                    command.Parameters.Add("PhoneNumber", OracleDbType.NVarchar2).Value = staff.PhoneNumber;

                    await command.ExecuteNonQueryAsync();
                }
            }
            
        }

        public async Task DeleteMedicalStaffById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM \"MEDICALSTAFF\" WHERE ID = :ID";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<MedicalStaff>?> GetAllMedicalStaff()
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<MedicalStaff> medicalStaffList = new List<MedicalStaff>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getAllMed, connection))
                {

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            MedicalStaff staff = new MedicalStaff
                            {

                                ID = new Guid((byte[])reader["ID"]),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FIRSTNAME"].ToString(),
                                Speciality = reader["Speciality"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),

                                /*ID = reader.GetGuid(reader.GetOrdinal("ID")),
                                LastName = reader.GetString(reader.GetOrdinal("LASTNAME")),
                                FirstName = reader.GetString(reader.GetOrdinal("FIRSTNAME")),
                                Speciality = reader.GetString(reader.GetOrdinal("SPECIALITY")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PHONENUMBER")),*/

                            };

                            medicalStaffList.Add(staff);
                        }
                    }
                }
            }
            if(medicalStaffList?.Count > 0)
            {
                return medicalStaffList;
            }
            else
            return null;
        }

        public async Task<MedicalStaff?> GetMedicalStaffById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getMedStaffById, connection))
                {
                    command.Parameters.Add("medId", OracleDbType.Raw).Value = id;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            MedicalStaff staff = new MedicalStaff
                            {

                                ID = new Guid((byte[])reader["ID"]),                   
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                Speciality = reader["Speciality"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                
                            };

                            return staff;
                        }
                    }
                }
            }
            return null;
        }

        public async Task<MedicalStaff?> GetMedicalStaffByName(string name)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Queries.getMedStaffByName, connection))
                {
                    command.Parameters.Add("FirstName", OracleDbType.NVarchar2).Value = name;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            MedicalStaff staff = new MedicalStaff
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                Speciality = reader["Speciality"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),

                            };

                            return staff;
                        }
                    }
                }
            }
            return null;
        }

        public async Task UpdateMedicalStaff(MedicalStaff staff)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                string updateUserQuery = @"UPDATE ""MEDICALSTAFF"" SET 
                                    ID = :ID,
                                    LastName = :LastName,
                                    FIRSTNAME = :FirstName,
                                    Speciality = :Speciality,
                                    PhoneNumber = :PhoneNumber
                                    WHERE ID = :ID";

                using (OracleCommand command = new OracleCommand(updateUserQuery, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = staff.ID;
                    command.Parameters.Add("LastName", OracleDbType.NVarchar2).Value = staff.LastName;
                    command.Parameters.Add("FirstName", OracleDbType.NVarchar2).Value = staff.FirstName;
                    command.Parameters.Add("Speciality", OracleDbType.NVarchar2).Value = staff.Speciality;
                    command.Parameters.Add("PhoneNumber", OracleDbType.NVarchar2).Value = staff.PhoneNumber;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
