using System;
using University.Core.Interfaces;

namespace University.Core.Entities
{
    public class Lecture : EntityBase, IAggregateRoot
    {

        public string Name { get; set; }

        public DayOfWeek GivenDayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int LectureTheaterId { get; set; }

        public LectureTheater LectureTheater { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public double GetDurationInMinutes()
        {
            return EndTime.Subtract(StartTime).TotalMinutes;
        }
    }
}
