using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ResumeForm, ResumeFormDto>();
            CreateMap<CreateResumeFormDto, ResumeForm>();
            CreateMap<UpdateResumeFormDto, ResumeForm>();

            CreateMap<RegistrationForm, RegistrationFormDto>();
            CreateMap<CreateRegistrationFormDto, RegistrationForm>();
            CreateMap<UpdateRegistrationFormDto, RegistrationForm>();
        }
    }
}
