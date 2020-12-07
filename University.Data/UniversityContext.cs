using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
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

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(255)");

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.Name == "CreatedAt")))
                property.SetDefaultValueSql("getdate()");

            CreateRelationships(modelBuilder);

            ApplyConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LectureTheaterConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
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