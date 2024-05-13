using AutoMapper;
using Microservices.Models;
using Microservices.Models.Dtos;
using Microservices.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers
{
    [Route("api/Patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientRepository _patientRepository;

        private readonly IMapper _mapper;


        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var patients = await _patientRepository.GetAllPatients();

            if (!patients.Any())
            {
                return NotFound();
            }

            var patientDtos = _mapper.Map<IEnumerable<PatientDto>>(patients);

            return Ok(patientDtos);
        }


        //[HttpGet("{id:int}")]
        //public ActionResult<PatientDto> GetPatientId(int id)
        //{
        //    var patient = _patientRepository.GetPatientById(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    var patientDto = _mapper.Map<PatientDto>(patient);
        //    return Ok(patientDto);
        //}


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatientDto>> GetPatientById(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            var patientDto = patient.ToDto(); // Usando el método de extensión ToDto
            return Ok(patientDto);
        }


        [HttpPatch("{id:int}")]
        public async Task<ActionResult<PatientDto>> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest("Invalid patient data.");
            }

            var patientFromDb = await _patientRepository.GetPatientById(id);
            if (patientFromDb == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            // Manual mapping from DTO to Patient entity
            patientFromDb.Name = patientDto.Name;  // Assuming Name is a simple string for this example
            patientFromDb.Email = patientDto.Email;
            patientFromDb.ContactInformation = patientDto.ContactInformation;
            patientFromDb.DateOfBirth = patientDto.DateOfBirth;
            patientFromDb.MedicalHistory = patientDto.MedicalHistory;

            patientFromDb = await _patientRepository.UpdatePatient(patientFromDb);

            var updatedPatientDto = patientFromDb.ToDto(); // Using the ToDto extension method
            return Ok(updatedPatientDto);
        }



        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient([FromBody] PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest("Patient data is null");
            }

            // Manual mapping from DTO to new Patient entity
            var patient = new Patient
            {
                Name = new Name(patientDto.Name.value),  // Assuming Name is a simple string for this example
                Email = new Email(patientDto.Email.value),
                ContactInformation = patientDto.ContactInformation,
                DateOfBirth = patientDto.DateOfBirth,
                MedicalHistory = patientDto.MedicalHistory
            };

            var createdPatient = await _patientRepository.CreateNewPatient(patient);

            if (createdPatient == null)
            {
                return BadRequest("Failed to create the patient");
            }

            var resultDto = createdPatient.ToDto(); // Using the ToDto extension method
            return CreatedAtAction(nameof(GetPatientById), new { id = resultDto.Id }, resultDto);

        }




        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PatientDto>> DeletePatient(int id)
        {
            // Primero obtén el paciente para tener la información para responder después de eliminarlo
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            // Convertir a DTO antes de eliminar, si deseas enviar los datos del paciente eliminado como respuesta
            var patientDto = patient.ToDto(); // Usando el método de extensión ToDto

            // Ahora procede a eliminar el paciente
            bool deleted = await _patientRepository.DeletePatient(id);
            if (deleted)
            {
                return Ok(patientDto);  // Devuelve el DTO del paciente eliminado, aunque típicamente se usa NoContent()
            }
            else
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }









    }
}
