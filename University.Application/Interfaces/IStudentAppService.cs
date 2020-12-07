using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace University.Application.Interfaces
{
    public interface IStudentAppService : IDisposable
    {
        Task<IEnumerable<ViewModels.StudentViewModel>> GetAll();

        Task<ViewModels.StudentViewModel> GetById(int id);

        Task<bool> Create(ViewModels.StudentViewModel vmStudent);

        Task<bool> Update(ViewModels.StudentViewModel vmStudent);

        Task<bool> Delete(int id);
    }
}