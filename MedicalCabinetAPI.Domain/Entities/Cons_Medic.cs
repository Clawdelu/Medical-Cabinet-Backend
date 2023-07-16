namespace MedicalCabinetAPI.Domain.Entities
{
    public record Cons_Medic
    {
        public Guid ID { get; set; }
        public Guid ID_consultation { get; set; }
        public Guid ID_medication { get; set; }
        public int PrescribedDoseMedication { get; set; }
        public int PeriodOfTreatment { get; set; }

    }
}
