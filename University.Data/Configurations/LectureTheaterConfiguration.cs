using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using University.Core.Entities;

namespace University.Data.Configurations
{

    public class LectureTheaterConfiguration : IEntityTypeConfiguration<LectureTheater>
    {
        public void Configure(EntityTypeBuilder<LectureTheater> builder)
        {
            builder.HasData(SeedLectureTheater());
        }

        private List<LectureTheater> SeedLectureTheater()
        {
            var random = new Random();

            var lectureTheaters = new List<LectureTheater>
            {
                new LectureTheater
                {
                    Id = 1,
                    Name = "LectureTheater 1",
                    NominatedCapacity = GetRandomNominatedCapacity(random),
                },
                new LectureTheater
                {
                    Id = 2,
                    Name = "LectureTheater 2",
                    NominatedCapacity = GetRandomNominatedCapacity(random),
                },
                new LectureTheater
                {
                    Id = 3,
                    Name = "LectureTheater 3",
                    NominatedCapacity = GetRandomNominatedCapacity(random),
                },
                new LectureTheater
                {
                    Id = 4,
                    Name = "LectureTheater 4",
                    NominatedCapacity = GetRandomNominatedCapacity(random),
                },
                new LectureTheater
                {
                    Id = 5,
                    Name = "LectureTheater 5",
                    NominatedCapacity = GetRandomNominatedCapacity(random),
                },
            };

            return lectureTheaters;
        }

        private int GetRandomNominatedCapacity(Random random)
        {
            return random.Next(1, 10);
        }
    }
}