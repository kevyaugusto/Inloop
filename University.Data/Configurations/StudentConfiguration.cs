using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using University.Core.Entities;

namespace University.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasData(SeedStudents());
        }

        private List<Student> SeedStudents()
        {
            var students = new List<Student> {
                new Student
                {
                    Id = 1,
                    FirstName = "Student FirstName 1",
                    LastName = "Student LastName 1"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Student FirstName 2",
                    LastName = "Student LastName 2"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Student FirstName 3",
                    LastName = "Student LastName 3"
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Student FirstName 4",
                    LastName = "Student LastName 4"
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Student FirstName 5",
                    LastName = "Student LastName 5"
                },
            };

            return students;
        }
    }
}