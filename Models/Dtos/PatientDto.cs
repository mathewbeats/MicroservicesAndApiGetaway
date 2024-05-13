namespace Microservices.Models.Dtos
{
    public class PatientDto
    {

        public int Id { get; set; }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public string ContactInformation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MedicalHistory { get; set; }
    }
}
