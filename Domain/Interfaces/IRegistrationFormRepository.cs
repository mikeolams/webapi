using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRegistrationFormRepository
    {
        Task<List<RegistrationForm>> GetAllAsync();
        Task<RegistrationForm> GetAsync(int userId);
        Task DeleteAsync(int userId);
        Task AddAsync(RegistrationForm registrationForm);
        Task UpdateAsync(RegistrationForm registrationForm);
    }
}
