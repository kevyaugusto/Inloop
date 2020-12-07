using System.Collections.Generic;
using University.Core.Interfaces;

namespace University.Core.Entities
{
    public class Student : EntityBase, IAggregateRoot
    {
        public Student() { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<StudentSubject> StudentsSubjects { get; set; }
    }
}