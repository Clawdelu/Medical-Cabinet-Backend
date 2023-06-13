using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consulationService;
        private readonly ILogger<ConsultationController> _logger;

        public ConsultationController(IConsultationService consultationService, ILogger<ConsultationController> logger)
        {
            this._consulationService = consultationService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConsultationsAsync()
        {
            try
            {
                var consultation = await _consulationService.GetConsultationAsync();

                return Ok(consultation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultationByIdAsync(Guid id)
        {
            try
            {
                var consultation = await _consulationService.GetConsultationByIdAsync(id);

                return Ok(consultation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetConsultationByNameAsync(string name)
        {
            try
            {
                var consultation = await _consulationService.GetConsultationByNameAsync(name);

                return Ok(consultation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddConsultation(ConsultationDto consultationDto)
        {
            try
            {
                var consultation = await _consulationService.AddConsultationAsync(consultationDto);

                return Ok(consultation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateConsultationByIdAsync([FromBody] ConsultationDto consultationDto, Guid id)
        {
            try
            {
               await _consulationService.UpdateConsultationByIdAsync(consultationDto,id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConsultationById(Guid id)
        {
            try
            {
                await _consulationService.DeleteConsultationByIdAsync(id);

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
