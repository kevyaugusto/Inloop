using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using University.Core.Entities;

namespace University.Data.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasData(SeedStudentsSubjects());
        }

        private List<StudentSubject> SeedStudentsSubjects()
        {
            var studentsSubjects = new List<StudentSubject>
            {
                new StudentSubject
                {
                    StudentId = 1,
                    SubjectId = 1,
                },
                new StudentSubject
                {
                    StudentId = 1,
                    SubjectId = 2,
                },
                new StudentSubject
                {
                    StudentId = 2,
                    SubjectId = 1,
                },
                new StudentSubject
                {
                    StudentId = 2,
                    SubjectId = 2,
                },
                new StudentSubject
                {
                    StudentId = 3,
                    SubjectId = 1,
                },
                new StudentSubject
                {
                    StudentId = 3,
                    SubjectId = 2,
                },
                new StudentSubject
                {
                    StudentId = 3,
                    SubjectId = 3,
                },
                new StudentSubject
                {
                    StudentId = 4,
                    SubjectId = 1,
                },
                new StudentSubject
                {
                    StudentId = 5,
                    SubjectId = 2,
                },
                new StudentSubject
                {
                    StudentId = 5,
                    SubjectId = 4,
                },
            };

            return studentsSubjects;
        }
    }
}
