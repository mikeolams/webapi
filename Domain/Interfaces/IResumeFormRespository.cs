using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IResumeFormRespository
    {
        Task<List<ResumeForm>> GetAllAsync();
        Task<ResumeForm> GetAsync(int userId);
        Task DeleteAsync(int userId);
        Task AddAsync(ResumeForm resumeForm);
        Task UpdateAsync(ResumeForm resumeForm);
    }
}
