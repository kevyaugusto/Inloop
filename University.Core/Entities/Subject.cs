using System.Collections.Generic;

namespace University.Core.Entities
{
    public class Subject : EntityBase, Interfaces.IAggregateRoot
    {
        public string Name { get; set; }

        public IList<StudentSubject> StudentsSubjects { get; set; }

        public List<Lecture> Lectures { get; set; }
    }
}
