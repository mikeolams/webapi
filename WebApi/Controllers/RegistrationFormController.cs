using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationFormController : ControllerBase
    {
        private readonly IRegistrationFormService _registrationFormService;
        public RegistrationFormController(IRegistrationFormService registrationFormService)
        {
            _registrationFormService = registrationFormService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _registrationFormService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _registrationFormService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateRegistrationFormDto dto)
        {
            await _registrationFormService.AddAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRegistrationFormDto dto)
        {
            await _registrationFormService.UpdateAsync(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _registrationFormService.DeleteAsync(id);
            return Ok();
        }
    }
}
