﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.Data;

namespace University.Data.Migrations
{
    [DbContext(typeof(UniversityContext))]
    partial class UniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("University.Core.Entities.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("GivenDayOfWeek")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LectureTheaterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LectureTheaterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("University.Core.Entities.LectureTheater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("NominatedCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LectureTheaters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "LectureTheater 1",
                            NominatedCapacity = 7
                        },
                        new
                        {
                            Id = 2,
                            Name = "LectureTheater 2",
                            NominatedCapacity = 4
                        },
                        new
                        {
                            Id = 3,
                            Name = "LectureTheater 3",
                            NominatedCapacity = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "LectureTheater 4",
                            NominatedCapacity = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "LectureTheater 5",
                            NominatedCapacity = 8
                        });
                });

            modelBuilder.Entity("University.Core.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Student FirstName 1",
                            LastName = "Student LastName 1"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Student FirstName 2",
                            LastName = "Student LastName 2"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Student FirstName 3",
                            LastName = "Student LastName 3"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Student FirstName 4",
                            LastName = "Student LastName 4"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Student FirstName 5",
                            LastName = "Student LastName 5"
                        });
                });

            modelBuilder.Entity("University.Core.Entities.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentsSubjects");
                });

            modelBuilder.Entity("University.Core.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Subject 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Subject 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Subject 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Subject 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Subject 5"
                        });
                });

            modelBuilder.Entity("University.Core.Entities.Lecture", b =>
                {
                    b.HasOne("University.Core.Entities.LectureTheater", "LectureTheater")
                        .WithMany()
                        .HasForeignKey("LectureTheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Core.Entities.Subject", "Subject")
                        .WithMany("Lectures")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("University.Core.Entities.StudentSubject", b =>
                {
                    b.HasOne("University.Core.Entities.Student", "Student")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Core.Entities.Subject", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
