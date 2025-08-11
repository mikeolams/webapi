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
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly IRegistrationFormRepository _registrationFormRepository;
        private readonly IMapper _mapper;
        public RegistrationFormService(IRegistrationFormRepository registrationFormRepository, IMapper mapper)
        {
            _mapper = mapper;
            _registrationFormRepository = registrationFormRepository;
        }

        public async Task AddAsync(CreateRegistrationFormDto registrationForm)
        {
            await _registrationFormRepository.AddAsync(_mapper.Map<RegistrationForm>(registrationForm));
        }

        public async Task DeleteAsync(int userId)
        {
            await _registrationFormRepository.DeleteAsync(userId);
        }

        public async Task<List<RegistrationFormDto>> GetAllAsync()
        {
            return _mapper.Map<List<RegistrationFormDto>>(await _registrationFormRepository.GetAllAsync());
        }

        public async Task<RegistrationFormDto> GetByIdAsync(int userId)
        {
            return _mapper.Map<RegistrationFormDto>(await _registrationFormRepository.GetAsync(userId));
        }

        public async Task UpdateAsync(UpdateRegistrationFormDto registrationForm)
        {
            await _registrationFormRepository.UpdateAsync(_mapper.Map<RegistrationForm>(registrationForm));
            //throw new NotImplementedException();
        }
    }
}
