using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RegistrationFormRepository : IRegistrationFormRepository
    {
        private readonly ApplicationDbContext _context;
        public RegistrationFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RegistrationForm registrationForm)
        {
            //throw new NotImplementedException();
            await _context.RegistrationForms.AddAsync(registrationForm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var registrationForm = await _context.RegistrationForms.FindAsync(userId);
            if (registrationForm != null)
            {
                _context.RegistrationForms.Remove(registrationForm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<RegistrationForm>> GetAllAsync() => await _context.RegistrationForms.ToListAsync();

        public async Task<RegistrationForm> GetAsync(int userId)
        {
            return await _context.RegistrationForms.FindAsync(userId);
        }

        public async Task UpdateAsync(RegistrationForm registrationForm)
        {
            //throw new NotImplementedException();
            _context.RegistrationForms.Update(registrationForm);
            await _context.SaveChangesAsync();
        }
    }
}
