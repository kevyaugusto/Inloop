﻿using AutoMapper;

namespace University.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Core.Entities.Student, ViewModels.StudentViewModel>();
        }
    }
}
