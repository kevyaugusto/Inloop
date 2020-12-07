using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Core.Entities;
using University.Core.Interfaces;

namespace University.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly UniversityContext UniversityContext;
        protected readonly DbSet<Student> DbSet;

        public StudentRepository(UniversityContext universityContext)
        {
            UniversityContext = universityContext;
            DbSet = UniversityContext.Set<Student>();
        }

        public IUnitOfWork UnitOfWork => UniversityContext;

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Student student)
        {
            DbSet.Add(student);
        }

        public void Update(Student student)
        {
            DbSet.Update(student);
        }

        public void Delete(Student student)
        {
            DbSet.Update(student); //I could have used DbSet.Remove, however, data should't be deleted of the database, therefore, I set DateTime.Now in the Student.DeletedAt field.
        }

        public void Dispose()
        {
            UniversityContext.Dispose();
        }
    }
}