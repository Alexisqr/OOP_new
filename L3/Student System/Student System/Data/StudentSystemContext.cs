using Microsoft.EntityFrameworkCore;
using Student_System.Data.EntityConfiguration;
using Student_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_System.Data
{

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Config.ConnectionString);
            }
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentsConfiguration());

            builder.ApplyConfiguration(new CourseConfiguration());

            builder.ApplyConfiguration(new ResourceConfiguration());

            builder.ApplyConfiguration(new HomeworkConfiguration());

            builder.ApplyConfiguration(new StudentCourseConfiguration());
            Seeder(builder);
        }
         
        public static void Seeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().HasData(
                new Students {StudentId=1, Name = "John Doe", PhoneNumber = "1234567891", RegisteredOn = DateTime.ParseExact("12-06-2018", "dd-MM-yyyy", null), Birthday = DateTime.ParseExact("12-06-2018", "dd-MM-yyyy", null) },
                new Students { StudentId = 2, Name = "Jane Smith", PhoneNumber = "1234567891", RegisteredOn = DateTime.ParseExact("12-06-2018", "dd-MM-yyyy", null), Birthday = DateTime.ParseExact("12-06-2018", "dd-MM-yyyy", null) }

            );
            modelBuilder.Entity<Course>().HasData(
             new Course { CourseId = 1 ,Name = "C# Fundamentals", Description = "1234567891", StartDate = "12-06-2018", EndDate = "12-06-2018", Price = 330.00m },
              new Course { CourseId = 2, Name = "C# Fundamentals2", Description = "1234567891", StartDate = "12-06-2018", EndDate = "12-06-2018", Price = 330.00m }

         );
            modelBuilder.Entity<Resource>().HasData(
            new Resource {ResourceId =1, Name = "C# Fundamentals - Stacks and Queues", Url = "www.softuni.com/c#fundamentals/labs", ResourceType = ResourceType.Document, CourseId = 1 }


        );
            modelBuilder.Entity<StudentCourse>().HasData(
          new StudentCourse { CourseId = 1, StudentId = 1 }


      );
            modelBuilder.Entity<Homework>().HasData(
        new Homework {HomeworkId = 1, Content = "Stacks and Queues - Lab", ContentType = ContentType.Application, SubmissionTime = "08-02-2018", CourseId = 1, StudentId = 1 }


    );
        }

    }
}
