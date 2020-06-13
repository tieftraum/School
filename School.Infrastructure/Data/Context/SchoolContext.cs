using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace School.Infrastructure.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
            Database.EnsureCreated();
        }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<SchoolClass> SchoolClasses { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //if (!optionsBuilder.IsConfigured)
        //    //{
        //    //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //    //       .SetBasePath(Directory.GetCurrentDirectory())
        //    //       .AddJsonFile("appsettings.json")
        //    //       .Build();
        //    //    var connectionString = configuration.GetConnectionString("Default");
        //    //    optionsBuilder.UseSqlServer(connectionString);
        //    //}
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("Teacher_ID");
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.DoB).HasColumnType("date");
                entity.Property(e => e.DoD).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("Student_ID");
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.DoB).HasColumnType("date");
                entity.Property(e => e.DoD).HasColumnType("date");
                entity.HasOne(e => e.Class).WithMany(e => e.Students).HasForeignKey(e => e.ClassId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("Course_Id");
                entity.HasIndex(e => e.Title).IsUnique();
                entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<SchoolClass>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.HasKey(e => e.GradeId).HasName("Grade_Id");
                entity.HasIndex(e => e.Grade).IsUnique();
                entity.Property(e => e.Grade).HasMaxLength(3);
            });

        }
    }
}
