using Microservices.Models;
using Microservices.Models.Dtos;

namespace Microservices.Repository.IRepository
{
    public interface IPatientRepository
    {

        Task<IEnumerable<Patient>> GetAllPatients();

        Task<Patient>GetPatientById(int id);

        Task<bool> PatientExist(int id);

        Task<bool> DeletePatient(int id);

        Task<Patient> CreateNewPatient(Patient patient);
        Task<Patient> UpdatePatient(Patient patient);
    }
}
