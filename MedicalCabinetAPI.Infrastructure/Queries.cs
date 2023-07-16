using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure
{
    public static class Queries
    {
        //Medical Staff section -----------------------------------------------------------------------------

        public const string insertMedicalStaff = @"INSERT INTO ""MEDICALSTAFF"" (ID, LastName, FIRSTNAME, Speciality, PhoneNumber, DELETEMS) 
                                        VALUES (:ID, :LastName, :FirstName, :Speciality, :PhoneNumber, :DELETEMS)";
        public const string getMedStaffById = "SELECT * FROM \"MEDICALSTAFF\" WHERE ID = :medId";
        public const string getMedStaffByName = "SELECT * FROM \"MEDICALSTAFF\" WHERE UPPER(FirstName) = :FirstName";
        public const string getAllMed = @"SELECT * FROM ""MEDICALSTAFF"" WHERE DELETEMS = 0 ";
        public const string getAllMedHard = @"SELECT * FROM ""MEDICALSTAFF""";

        //---------------------------------------------------------------------------------------------------

        //Patient section -----------------------------------------------------------------------------------

        public const string insertPatient = @"INSERT INTO ""PATIENT"" (ID, LastName, FirstName, DateOfBirth, Address, PhoneNumber, ID_medicalStaff)
                                    VALUES (:ID, :LastName, :FirstName, :DateOfBirth, :Address, :PhoneNumber, :ID_medicalStaff)";
        public const string deletePatient = "DELETE FROM \"PATIENT\" WHERE ID = :ID";
        public const string getAllPatients = @"SELECT * FROM ""PATIENT""";
        public const string getPatientById = "SELECT * FROM \"PATIENT\" WHERE ID = :patientID";
        public const string getPatientByName = "SELECT * FROM \"PATIENT\" WHERE FirstName = :FirstName";
        public const string updatePatient = @"UPDATE ""PATIENT"" SET 
                                    ID = :ID,
                                    LastName = :LastName,
                                    FIRSTNAME = :FirstName,
                                    DateOfBirth = :DateOfBirth,
                                    Address = :Address,
                                    PhoneNumber = :PhoneNumber,
                                    ID_medicalStaff = :ID_medicalStaff
                                    WHERE ID = :ID ";

        //---------------------------------------------------------------------------------------------------

        //Medication section --------------------------------------------------------------------------------
        public const string insertMedication = @"INSERT INTO ""MEDICATION"" (ID, Name, AvailableQuantity, ExpirationDate, ID_medicalStaff)
                                    VALUES (:ID, :Name, :AvailableQuantity, :ExpirationDate, :ID_medicalStaff)";
        public const string deleteMedication = "DELETE FROM \"MEDICATION\" WHERE ID = :ID";
        public const string getAllMedications = @"SELECT * FROM ""MEDICATION""";
        public const string getMedicationById = "SELECT * FROM \"MEDICATION\" WHERE ID = :medID";
        public const string getMedicationByName = "SELECT * FROM \"MEDICATION\" WHERE Name = :Name";
        public const string updateMedication = @"UPDATE ""MEDICATION"" SET 
                                    ID = :ID,
                                    Name = :Name,
                                    AvailableQuantity = :AvailableQuantity,
                                    ExpirationDate = :ExpirationDate,
                                    ID_medicalStaff = :ID_medicalStaff                                
                                    WHERE ID = :ID";

        //---------------------------------------------------------------------------------------------------

        //Consultation section --------------------------------------------------------------------------------
        public const string insertConsultation = @"INSERT INTO ""CONSULTATION"" (ID, ID_Patient, ID_MedicalStaff, DateOfConsultation, Symptoms, Diagnosis)
                                    VALUES (:ID, :ID_Patient, :ID_MedicalStaff, :DateOfConsultation, :Symptoms, :Diagnosis)";
        public const string deleteConsultation = "DELETE FROM \"CONSULTATION\" WHERE ID = :ID";
        public const string getAllConsultation = @"SELECT * FROM ""CONSULTATION""";
        public const string getConsultationById = "SELECT * FROM \"CONSULTATION\" WHERE ID = :consID";
        public const string getConsultationByPatientId = "SELECT * FROM \"CONSULTATION\" WHERE ID_Patient = :patientID";
        public const string updateConsultation = @"UPDATE ""CONSULTATION"" SET 
                                    ID = :ID,
                                    ID_Patient = :ID_Patient,
                                    ID_MedicalStaff = :ID_MedicalStaff,
                                    DateOfConsultation = :DateOfConsultation,
                                    Symptoms = :Symptoms,
                                    Diagnosis = :Diagnosis
                                    WHERE ID = :ID";      

        //---------------------------------------------------------------------------------------------------

        //CONS_MEDIC section --------------------------------------------------------------------------------
       
        public const string insertCons_Medic = @"INSERT INTO ""CONS_MEDIC"" (ID ,ID_consultation, ID_medication, PrescribedDoseMedication, PeriodOfTreatment)
                                            VALUES (:ID, :ID_consultation, :ID_medication, :PrescribedDoseMedication, :PeriodOfTreatment)";
        public const string deleteCons_Medic = "DELETE FROM \"CONS_MEDIC\" WHERE ID_consultation = :ID";
        public const string getCons_MedicByConsultationId = "SELECT * FROM \"CONS_MEDIC\" WHERE ID_consultation = :ID_consultation";
        public const string updateCons_Medic = @"UPDATE ""CONS_MEDIC"" SET 
                                    ID = :ID,
                                    ID_consultation = :ID_consultation,
                                    ID_medication = :ID_medication,
                                    PrescribedDoseMedication = :PrescribedDoseMedication,
                                    PeriodOfTreatment = :PeriodOfTreatment                                   
                                    WHERE ID = :ID";
        public const string getCons_MedicById = "SELECT * FROM \"CONS_MEDIC\" WHERE ID = :ID";


        //---------------------------------------------------------------------------------------------------
    }
}
