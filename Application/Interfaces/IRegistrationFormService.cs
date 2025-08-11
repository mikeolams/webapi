using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRegistrationFormService
    {
        Task<List<RegistrationFormDto>> GetAllAsync();
        Task<RegistrationFormDto> GetByIdAsync(int userId);
        Task AddAsync(CreateRegistrationFormDto registrationForm);
        Task DeleteAsync(int userId);
        Task UpdateAsync(UpdateRegistrationFormDto registrationForm);

    }
}
