using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResumeFormService : IResumeFormService
    {
        private readonly IResumeFormRespository _resumeFormRepository;
        private readonly IMapper _mapper;
        public ResumeFormService(IResumeFormRespository resumeFormRepository, IMapper mapper)
        {
            _mapper = mapper;
            _resumeFormRepository = resumeFormRepository;
        }

        public async Task AddAsync(CreateResumeFormDto resumeForm)
        {
            await _resumeFormRepository.AddAsync(_mapper.Map<ResumeForm>(resumeForm));
        }

        public async Task DeleteAsync(int userId)
        {
            await _resumeFormRepository.DeleteAsync(userId);
        }

        public async Task<List<ResumeFormDto>> GetAllAsync()
        {
            return _mapper.Map<List<ResumeFormDto>>(await _resumeFormRepository.GetAllAsync());
        }

        public async Task<ResumeFormDto> GetByIdAsync(int userId)
        {
            return _mapper.Map<ResumeFormDto>(await _resumeFormRepository.GetAsync(userId));
        }

        public async Task UpdateAsync(UpdateResumeFormDto resumeForm)
        {
            await _resumeFormRepository.UpdateAsync(_mapper.Map<ResumeForm>(resumeForm));
        }
    }
}
