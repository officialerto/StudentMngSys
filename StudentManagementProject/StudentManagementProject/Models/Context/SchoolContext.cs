using StudentManagementProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementProject.Models.Context
{
    public class SchoolContext : DbContext
    {
        //TABLES
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //FLUENT API
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.teacher_id);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.student_id);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.course_id);

            base.OnModelCreating(modelBuilder);
        }


    }
}