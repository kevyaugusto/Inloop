using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Application.Interfaces;
using University.Application.ViewModels;
using University.Core.Interfaces;

namespace University.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentAppService(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAll()
        {
            IEnumerable<Core.Entities.Student> students = await _studentRepository.GetAll();

            IEnumerable<StudentViewModel> vmStudents = _mapper.Map<IEnumerable<StudentViewModel>>(students);

            return vmStudents;
        }

        public async Task<StudentViewModel> GetById(int id)
        {
            Core.Entities.Student student = await _studentRepository.GetById(id);

            StudentViewModel vmStudents = _mapper.Map<StudentViewModel>(student);

            return vmStudents;
        }

        public async Task<bool> Create(StudentViewModel vmStudent)
        {
            Core.Entities.Student student = _mapper.Map<Core.Entities.Student>(vmStudent);
            _studentRepository.Add(student);
            return await _studentRepository.UnitOfWork.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Core.Entities.Student student = await _studentRepository.GetById(id);
            student.DeletedAt = DateTime.Now;
            _studentRepository.Delete(student);
            return await _studentRepository.UnitOfWork.Save();
        }

        public async Task<bool> Update(StudentViewModel vmStudent)
        {
            Core.Entities.Student student = _mapper.Map<Core.Entities.Student>(vmStudent);
            student.LastUpdate = DateTime.Now;
            _studentRepository.Update(student);
            return await _studentRepository.UnitOfWork.Save();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}