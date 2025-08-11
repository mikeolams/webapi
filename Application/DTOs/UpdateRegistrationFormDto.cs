using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateRegistrationFormDto(int userId, string FullName, string Email, string Password, string ConfirmPassword, byte[] PassportPhotograph)
    {
        public int userId { get; } = userId;
        public string FullName { get; } = FullName;
        public string Email { get; } = Email;
        public string Password { get; } = Password;
        public string ConfirmPassword { get; } = ConfirmPassword;
        public byte[] PassportPhotograph { get; } = PassportPhotograph;
        //public ResumeForm ResumeForm { get; } = ResumeForm;

    }
}
