using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ResumeForm
    {
        public int UserId { get; set; }
        public int ResumeId { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? EduHistory { get; set; }
        public string? WorkExperience { get; set; }

        [NotMapped]
        public required IFormFile PassportPhotograph { get; set; }
        public RegistrationForm RegistrationForm { get; set; }

    }
}
