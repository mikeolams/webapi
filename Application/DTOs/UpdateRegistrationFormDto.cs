using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    //public class UpdateRegistrationFormDto(int userId, string FullName, string Email, string Password, string ConfirmPassword, IFormFile? PassportPhotograph)
    //{
    //    public int userId { get; } = userId;
    //    public string FullName { get; } = FullName;
    //    public string Email { get; } = Email;
    //    public string Password { get; } = Password;
    //    public string ConfirmPassword { get; } = ConfirmPassword;
    //    public IFormFile? PassportPhotograph { get; } = PassportPhotograph;
    //    //public ResumeForm ResumeForm { get; } = ResumeForm;

    //    public UpdateRegistrationFormDto() { }

    //}
    public class UpdateRegistrationFormDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile? PassportPhotograph { get; set; }

        public UpdateRegistrationFormDto() { }

        public UpdateRegistrationFormDto(int userId, string fullName, string email, string password, string confirmPassword, IFormFile? passportPhotograph)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            PassportPhotograph = passportPhotograph;
        }

        //public static implicit operator UpdateRegistrationFormDto(UpdateRegistrationFormDto v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
