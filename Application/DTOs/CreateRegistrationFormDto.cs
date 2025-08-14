using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    //public class CreateRegistrationFormDto(string FullName, string Email, string Password, string ConfirmPassword, IFormFile? PassportPhotograph)
    //{
    //    public string FullName { get; } = FullName;
    //    public string Email { get; } = Email;
    //    public string Password { get; } = Password;
    //    public string ConfirmPassword { get; } = ConfirmPassword;
    //    public IFormFile? PassportPhotograph { get; } = PassportPhotograph;
    //    public CreateRegistrationFormDto() { }

    //    //public ResumeForm ResumeForm { get; } = ResumeForm;
    //}
    public class CreateRegistrationFormDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        [NotMapped]
        public IFormFile? PassportPhotograph { get; set; }

        public CreateRegistrationFormDto() { }
    }
}