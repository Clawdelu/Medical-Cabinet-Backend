namespace MedicalCabinetAPI.Domain.Entities
{
    public record Medication
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid ID_medicalStaff { get; set; }

    }
}
