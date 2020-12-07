using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using University.Core.Entities;

namespace University.Data.Configurations
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasData(SeedLectures());
        }

        private List<Lecture> SeedLectures()
        {
            var random = new Random();

            var lectures = new List<Lecture>
            {
                new Lecture
                {
                    Id = 1,
                    Name = $"Lecture 1",
                    StartTime = GetRandomStartTime(random),
                    EndTime = GetRandomEndTime(random),
                    GivenDayOfWeek = GetRandomDayOfWeek(random),
                    LectureTheaterId = 1,
                    SubjectId = 1
                },
                new Lecture
                {
                    Id = 2,
                    Name = $"Lecture 2",
                    StartTime = GetRandomStartTime(random),
                    EndTime = GetRandomEndTime(random),
                    GivenDayOfWeek = GetRandomDayOfWeek(random),
                    LectureTheaterId = 1,
                    SubjectId = 2
                },
                new Lecture
                {
                    Id = 3,
                    Name = $"Lecture 3",
                    StartTime = GetRandomStartTime(random),
                    EndTime = GetRandomEndTime(random),
                    GivenDayOfWeek = GetRandomDayOfWeek(random),
                    LectureTheaterId = 2,
                    SubjectId = 3
                },
                new Lecture
                {
                    Id = 4,
                    Name = $"Lecture 4",
                    StartTime = GetRandomStartTime(random),
                    EndTime = GetRandomEndTime(random),
                    GivenDayOfWeek = GetRandomDayOfWeek(random),
                    LectureTheaterId = 3,
                    SubjectId = 4
                }
            };

            return lectures;
        }

        private TimeSpan GetRandomStartTime(Random random)
        {
            int hour = random.Next(8, 12);
            return new TimeSpan(hour, 0, 0);
        }

        private TimeSpan GetRandomEndTime(Random random)
        {
            int hour = random.Next(13, 18);
            return new TimeSpan(hour, 0, 0);
        }

        private static DayOfWeek GetRandomDayOfWeek(Random random)
        {
            int randomValue = random.Next(0, 6);

            return (DayOfWeek)randomValue;
        }

    }
}