namespace MedicalCabinetAPI.Domain.Entities
{
    public record Patient
    {
        public Guid ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid ID_medicalStaff { get; set; }

    }
}
