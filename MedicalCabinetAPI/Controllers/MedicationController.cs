﻿using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Models;
using MedicalCabinetAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MedicalCabinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationService _medicationService;
        private readonly ILogger<MedicationController> _logger;

        public MedicationController(IMedicationService medicationService, ILogger<MedicationController> logger)
        {
            this._medicationService = medicationService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicationsAsync()
        {
            try
            {
                var medication = await _medicationService.GetMedicationsAsync();

                return Ok(medication);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ID/{id}")]
        public async Task<IActionResult> GetMedicationByIdAsync(Guid id)
        {
            try
            {
                var medication = await _medicationService.GetMedicationByIdAsync(id);

                return Ok(medication);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetMedicationByName([FromQuery] string name)
        {
            try
            {
                var medication = await _medicationService.GetMedicationByNameAsync(name);

                return Ok(medication);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMedicationAsync(MedicationDto medicationDto)
        {
            try
            {
                var medication = await _medicationService.AddMedicationAsync(medicationDto);

                return Ok(medication);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicationById([FromBody] MedicationDto medicationDto, Guid id)
        {
            try
            {
                await _medicationService.UpdateMedicationByIdAsync(medicationDto,id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMedicationById(Guid id)
        {
            try
            {
                await _medicationService.DeleteMedicationByIdAsync(id);

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
