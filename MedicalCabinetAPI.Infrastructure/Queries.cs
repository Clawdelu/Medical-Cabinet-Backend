using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetAPI.Infrastructure
{
    public static class Queries
    {
        public const string createMedicalStaff = @"INSERT INTO ""MEDICALSTAFF"" (ID, LastName, FIRSTNAME, Speciality, PhoneNumber) 
                                        VALUES (:ID, :LastName, :FirstName, :Speciality, :PhoneNumber)";
        public const string getMedStaffById = "SELECT * FROM \"MEDICALSTAFF\" WHERE ID = :medId";
        public const string getMedStaffByName = "SELECT * FROM \"MEDICALSTAFF\" WHERE FirstName = :FirstName";
        public const string getAllMed = @"SELECT * FROM ""MEDICALSTAFF"" ";
    }
}
