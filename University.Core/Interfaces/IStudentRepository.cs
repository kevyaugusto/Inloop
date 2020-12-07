using System.Collections.Generic;
using System.Threading.Tasks;
using University.Core.Entities;

namespace University.Core.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetById(int id);
        
        Task<IEnumerable<Student>> GetAll();

        void Add(Student student);
        
        void Update(Student student);

        void Delete(Student student);
    }
}
