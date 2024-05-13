using Microservices.Data;
using Microservices.Models;
using Microservices.Models.Dtos;
using Microservices.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Repository
{
    public class PatientRepository : IPatientRepository
    {


        private readonly ApplicationDbContext _context;


        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public async Task<bool> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Patient> CreateNewPatient(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }



        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            var patients = _context.Patients.OrderBy(p => p.Id).ToList();

            if (patients == null)
            {
                throw new ArgumentException(nameof(patients));
            }

            return patients;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<bool> PatientExist(int id)
        {
            return await _context.Patients.AnyAsync(x => x.Id == id);
        }


        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == patient.Id);
            if (existingPatient == null)
            {
                return null; // Cambiado para devolver nulo en lugar de lanzar una excepción.
            }

            // Mapeo explícito de propiedades, si es necesario. Considera usar AutoMapper si hay muchas.
            existingPatient.Name = patient.Name;
            existingPatient.ContactInformation = patient.ContactInformation;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.MedicalHistory = patient.MedicalHistory;

            await _context.SaveChangesAsync();
            return existingPatient;
        }



    }
}
