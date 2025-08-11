using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeFormController : ControllerBase
    {
        private readonly IResumeFormService _resumeFormService;
        public ResumeFormController(IResumeFormService resumeFormService)
        {
            _resumeFormService = resumeFormService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _resumeFormService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _resumeFormService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateResumeFormDto dto)
        {
            await _resumeFormService.AddAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateResumeFormDto dto)
        {
            await _resumeFormService.UpdateAsync(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _resumeFormService.DeleteAsync(id);
            return Ok();
        }
    }
}
