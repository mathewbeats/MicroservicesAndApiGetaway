using Microservices.BussinesLogic;

namespace Microservices.Models.Dtos
{
    public static class DtoConversions
    {
        public static PatientDto ToDto(this Patient patient)
        {
            if (patient is null)
                throw new ArgumentNullException(nameof(patient));

            return new PatientDto
            {
                Id = patient.Id,
                DateOfBirth = patient.DateOfBirth,
                Email = patient.Email,
                Name = patient.Name,
                ContactInformation = patient.ContactInformation,
                MedicalHistory = patient.MedicalHistory,
            };
        }

        public static IEnumerable<PatientDto> ToDtos(this IEnumerable<Patient> patients)
        {
            return patients.Select(patient => patient.ToDto());
        }
    }
}
