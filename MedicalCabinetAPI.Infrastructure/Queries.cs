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

        public const string insertMedicalStaff = @"INSERT INTO ""MEDICALSTAFF"" (ID, LastName, FIRSTNAME, Speciality, PhoneNumber) 
                                        VALUES (:ID, :LastName, :FirstName, :Speciality, :PhoneNumber)";
        public const string getMedStaffById = "SELECT * FROM \"MEDICALSTAFF\" WHERE ID = :medId";
        public const string getMedStaffByName = "SELECT * FROM \"MEDICALSTAFF\" WHERE FirstName = :FirstName";
        public const string getAllMed = @"SELECT * FROM ""MEDICALSTAFF"" ";

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
                                    PhoneNumber = :PhoneNumber
                                    ID_medicalStaff = :ID_medicalStaff
                                    WHERE ID = :ID";

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

        //---------------------------------------------------------------------------------------------------
    }
}
