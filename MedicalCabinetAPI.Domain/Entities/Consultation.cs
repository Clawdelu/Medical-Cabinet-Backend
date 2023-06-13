namespace MedicalCabinetAPI.Domain.Entities
{
    public record Consultation
    {
        public Guid ID { get; set; }
        public Guid ID_Patient { get; set; }
        public Guid ID_MedicalStaff { get; set; }
        public DateTime DateOfConsultation { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }

    }
}
