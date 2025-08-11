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
    public class ResumeFormRepository : IResumeFormRespository
    {
        private readonly ApplicationDbContext _context;
        public ResumeFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ResumeForm resumeForm)
        {
            await _context.ResumeForms.AddAsync(resumeForm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var resumeForm = await _context.ResumeForms.FindAsync(userId);
            if (resumeForm != null)
            {
                _context.ResumeForms.Remove(resumeForm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ResumeForm>> GetAllAsync() => await _context.ResumeForms.ToListAsync();

        public async Task<ResumeForm> GetAsync(int userId)
        {
            return await _context.ResumeForms.FindAsync(userId);
        }

        public async Task UpdateAsync(ResumeForm resumeForm)
        {
            _context.ResumeForms.Update(resumeForm);
            await _context.SaveChangesAsync();
        }
    }
}
