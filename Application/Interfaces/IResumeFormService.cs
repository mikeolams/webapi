using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IResumeFormService
    {
        Task<List<ResumeFormDto>> GetAllAsync();
        Task<ResumeFormDto> GetByIdAsync(int userId);
        Task AddAsync(CreateResumeFormDto resumeForm);
        Task DeleteAsync(int userId);
        Task UpdateAsync(UpdateResumeFormDto resumeForm);

    }
}
