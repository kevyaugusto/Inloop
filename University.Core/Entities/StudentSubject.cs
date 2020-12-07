using University.Core.Interfaces;

namespace University.Core.Entities
{
    public class StudentSubject : EntityBase, IAggregateRoot
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        //---------

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

    }
}
