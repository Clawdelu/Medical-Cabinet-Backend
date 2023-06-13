using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            try
            {
                var patient = await _patientService.GetPatientAsync();

                return Ok(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPatientByNameAsync(string name)
        {
            try
            {
                var patient = await _patientService.GetPatientByNameAsync(name);

                return Ok(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByIdAsync(Guid id)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(id);

                return Ok(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPatientAsync(PatientDto patientDto)
        {
            try
            {
                 var patient = await _patientService.AddPatientAsync(patientDto);

                return Ok(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePatientByIdAsync([FromBody] PatientDto patientDto,Guid id)
        {
            try
            {
                await _patientService.UpdatePatientByIdAsync(id,patientDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatientById(Guid id)
        {
            try
            {
               await _patientService.DeletePatientByIdAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
