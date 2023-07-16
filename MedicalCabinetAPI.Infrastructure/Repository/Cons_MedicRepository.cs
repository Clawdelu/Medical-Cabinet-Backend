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
    public class Cons_MedicRepository : ICons_MedicRepository
    {
        private readonly IConfiguration configuration;
        public Cons_MedicRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task AddCons_Medic(Cons_Medic cons_medic)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.insertCons_Medic, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = cons_medic.ID;
                    command.Parameters.Add("ID_consultation", OracleDbType.Raw).Value = cons_medic.ID_consultation;
                    command.Parameters.Add("ID_medication", OracleDbType.Raw).Value = cons_medic.ID_medication;
                    command.Parameters.Add("PrescribedDoseMedication", OracleDbType.Int32).Value = cons_medic.PrescribedDoseMedication;
                    command.Parameters.Add("PeriodOfTreatment", OracleDbType.Int32).Value = cons_medic.PeriodOfTreatment;              
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteCons_MedicById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.deleteCons_Medic, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Cons_Medic>?> GetCons_MedicByIdConsultation(Guid idConsultation)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            List<Cons_Medic> cons_medicList = new List<Cons_Medic>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getCons_MedicByConsultationId, connection))
                {
                    command.Parameters.Add("ID_consultation", OracleDbType.Raw).Value = idConsultation;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Cons_Medic cons_medic = new Cons_Medic
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                ID_consultation = reader.GetGuid(reader.GetOrdinal("ID_consultation")),
                                ID_medication = reader.GetGuid(reader.GetOrdinal("ID_medication")),
                                PrescribedDoseMedication = reader.GetInt32(reader.GetOrdinal("PrescribedDoseMedication")),
                                PeriodOfTreatment = reader.GetInt32(reader.GetOrdinal("PeriodOfTreatment"))
                            };

                            cons_medicList.Add(cons_medic);
                        }
                    }
                }
            }
            if (cons_medicList?.Count > 0)
            {
                return cons_medicList;
            }
            else
                return null;
        }
        public async Task<Cons_Medic?> GetCons_MedicById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
           
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.getCons_MedicById, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = id;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            Cons_Medic cons_medic = new Cons_Medic
                            {
                                ID = new Guid((byte[])reader["ID"]),
                                ID_consultation = reader.GetGuid(reader.GetOrdinal("ID_consultation")),
                                ID_medication = reader.GetGuid(reader.GetOrdinal("ID_medication")),
                                PrescribedDoseMedication = reader.GetInt32(reader.GetOrdinal("PrescribedDoseMedication")),
                                PeriodOfTreatment = reader.GetInt32(reader.GetOrdinal("PeriodOfTreatment"))
                            };

                           return cons_medic;
                        }
                    }
                }
            }
           
                return null;
        }

        public async Task UpdateCons_Medic(Cons_Medic cons_medic)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Queries.updateCons_Medic, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = cons_medic.ID;
                    command.Parameters.Add("ID_consultation", OracleDbType.Raw).Value = cons_medic.ID_consultation;
                    command.Parameters.Add("ID_medication", OracleDbType.Raw).Value = cons_medic.ID_medication;
                    command.Parameters.Add("PrescribedDoseMedication", OracleDbType.Int32).Value = cons_medic.PrescribedDoseMedication;
                    command.Parameters.Add("PeriodOfTreatment", OracleDbType.Int32).Value = cons_medic.PeriodOfTreatment;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
