using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalStaffController : ControllerBase
    {
        private readonly IMedicalStaffService _medicalStaffService;
        private readonly ILogger<MedicalStaffController> _logger;

        public MedicalStaffController(IMedicalStaffService medicalStaffService, ILogger<MedicalStaffController> logger)
        {
            this._medicalStaffService = medicalStaffService;
            this._logger = logger;
        }

        [HttpGet("all-soft")]
        public async Task<IActionResult> GetAllMedicalStaffAsync()
        {
            try
            {
                var listOfStaff = await _medicalStaffService.GetMedicalStaffAsync();

                return Ok(listOfStaff);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMedicalStaffHardAsync()
        {
            try
            {
                var listOfStaff = await _medicalStaffService.GetMedicalStaffHardAsync();

                return Ok(listOfStaff);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetMedicalStaffByIdAsync(Guid id)
        {
            try
            {
                var staff = await _medicalStaffService.GetMedicalStaffByIdAsync(id);

                return Ok(staff);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetMedicalStaffByNameAsync(string name)
        {
            try
            {
                var staff = await _medicalStaffService.GetMedicByNameAsync(name);

                return Ok(staff);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMedicalStaff(MedicalStaffDto medicalStaffDto)
        {
            try
            {
                var staff = await _medicalStaffService.AddMedicalStaffAsync(medicalStaffDto);

                return Ok(staff);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicalStaffByIdAsync([FromBody] MedicalStaffDto staffDto, Guid id)
        {
            try
            {
                var STAFF =  await _medicalStaffService.UpdateMedicalStaffByIdAsync(staffDto, id);

                return Ok(STAFF);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("soft-delete")]
        public async Task<IActionResult> DeleteMedicalStaffById(Guid id)
        {
            try
            {
                await _medicalStaffService.DeleteMedicalStaffByIdAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMedicalStaffByIdHARD(Guid id)
        {
            try
            {
                await _medicalStaffService.DeleteMedicalStaffByIdHardAsync(id);

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
