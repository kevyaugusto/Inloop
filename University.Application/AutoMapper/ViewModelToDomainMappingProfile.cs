using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using University.Application.ViewModels;
using University.Core.Entities;

namespace University.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, Student>().ForMember(dm => dm.StudentsSubjects, mo => mo.Ignore());
        }
    }
}