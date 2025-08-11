using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RegistrationForm
    {
        public int userId { get; set; }
        //public int RegistrationId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public byte[] PassportPhotograph { get; set; }
        public ResumeForm ResumeForm { get; set; }
    }
}
