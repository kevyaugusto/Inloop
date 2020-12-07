using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using University.Core.Entities;

namespace University.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(SeedSubjects());
        }

        private List<Subject> SeedSubjects()
        {
            var subjects = new List<Subject>()
            {
                new Subject
                {
                    Id = 1,
                    Name = "Subject 1",
                },
                new Subject
                {
                    Id = 2,
                    Name = "Subject 2",
                },
                new Subject
                {
                    Id = 3,
                    Name = "Subject 3",
                },
                new Subject
                {
                    Id = 4,
                    Name = "Subject 4",
                },
                new Subject
                {
                    Id = 5,
                    Name = "Subject 5",
                },
            };

            return subjects;
        }
    }
}