using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Core.Entities;
using University.Core.Interfaces;
using University.Data.Configurations;

namespace University.Data
{
    public class UniversityContext : DbContext, IUnitOfWork
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureTheater> LectureTheaters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentsSubjects { get; set; }

        public UniversityContext() { }

        public UniversityContext(DbContextOptions<UniversityContext> dbContextOptions)
            : base(dbContextOptions)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();

            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.AutoDetectChangesEnabled = false;

            Database.EnsureDeleted();

            bool dbCreatedSuccessfully = Database.EnsureCreated();

            if (dbCreatedSuccessfully)
            {
                SeedDatabase();
            }
        }

        private void SeedDatabase()
        {
            List<LectureTheater> lectureTheaters = SeedLectureTheater();
            List<Subject> subjects = SeedSubjects();
            List<Student> students = SeedStudents();
            this.SaveChanges();

            SeedStudentsSubjects(students, subjects);
            SeedLectures(lectureTheaters, subjects);

            this.SaveChanges();
        }

        private void SeedStudentsSubjects(List<Student> students, List<Subject> subjects)
        {
            var studentsSubjects = new List<StudentSubject>();
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var studentSubject = new StudentSubject
                {
                    StudentId = students.OrderBy(o => Guid.NewGuid()).First().Id,
                    SubjectId = subjects.OrderBy(o => Guid.NewGuid()).First().Id,
                    CreatedAt = DateTime.Now,
                };
                studentsSubjects.Add(studentSubject);
            }

            this.AddRange(studentsSubjects);
        }

        private List<LectureTheater> SeedLectureTheater()
        {
            var lectureTheaters = new List<LectureTheater>();
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var lectureTheater = new LectureTheater
                {
                    CreatedAt = DateTime.Now,
                    Name = $"LectureTheater {i}",
                    NominatedCapacity = GetRandomNominatedCapacity(random),
                };
                lectureTheaters.Add(lectureTheater);
            }

            this.AddRange(lectureTheaters);
            return lectureTheaters;
        }

        private int GetRandomNominatedCapacity(Random random)
        {
            return random.Next(1, 30);
        }

        private void SeedLectures(List<LectureTheater> lectureTheaters, List<Subject> subjects)
        {
            var lectures = new List<Lecture>();
            var random = new Random();

            for (int i = 1; i < 5; i++)
            {
                var lecture = new Lecture
                {
                    CreatedAt = DateTime.Now,
                    Name = $"Lecture {i}",
                    StartTime = GetRandomStartTime(random),
                    EndTime = GetRandomEndTime(random),
                    GivenDayOfWeek = GetRandomDayOfWeek(random),
                    LectureTheaterId = lectureTheaters.OrderBy(o => Guid.NewGuid()).First().Id,
                    SubjectId = subjects.OrderBy(o => Guid.NewGuid()).First().Id
                };
                lectures.Add(lecture);
            }

            this.AddRange(lectures);
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

        private List<Subject> SeedSubjects()
        {
            var subjects = new List<Subject>();

            for (int i = 1; i <= 20; i++)
            {
                var subject = new Subject
                {
                    CreatedAt = DateTime.Now,
                    Name = $"Subject {i}",
                };
                subjects.Add(subject);
            }

            this.AddRange(subjects);
            return subjects;
        }

        private List<Student> SeedStudents()
        {
            var students = new List<Student>();

            for (int i = 1; i <= 10; i++)
            {
                var student = new Student
                {
                    CreatedAt = DateTime.Now,
                    FirstName = $"Student FN {i}",
                    LastName = $"Student LN {i}"
                };
                students.Add(student);
            }

            this.AddRange(students);
            return students;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(255)");

            CreateRelationships(modelBuilder);

            ApplyConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }

        private void CreateRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>().HasKey(studentSubject => new { studentSubject.StudentId, studentSubject.SubjectId });
            modelBuilder.Entity<StudentSubject>()
                .HasOne(studentSubject => studentSubject.Student)
                .WithMany(student => student.StudentsSubjects)
                .HasForeignKey(studentSubject => studentSubject.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(studentSubject => studentSubject.Subject)
                .WithMany(subject => subject.StudentsSubjects)
                .HasForeignKey(studentSubject => studentSubject.SubjectId);

            modelBuilder.Entity<StudentSubject>().Ignore(ss => ss.Id);
        }

        public async Task<bool> Save()
        {
            bool success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}