using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateResumeFormDto(int userId, int ResumeId, string FullName, string Gender, DateOnly DateOfBirth, string Nationality, string EduHistory, string WorkExperience, IFormFile PassportPhotograph)
    {
        public int userId { get; } = userId;
        public int ResumeId { get; } = ResumeId;
        public string FullName { get; } = FullName;
        public string Gender { get; } = Gender;
        public DateOnly DateOfBirth { get; } = DateOfBirth;
        public string Nationality { get; } = Nationality;
        public string EduHistory { get; } = EduHistory;
        public string WorkExperience { get; } = WorkExperience;
        public IFormFile PassportPhotograph { get; } = PassportPhotograph;

        //public ResumeForm ResumeForm { get; } = ResumeForm;
    }
}
