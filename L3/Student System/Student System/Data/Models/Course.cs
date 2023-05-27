using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_System.Data.Models
{
    public class Course
    {
        private string v1;
        private DateTime dateTime1;
        private DateTime dateTime2;
        private decimal v2;

        public Course()
        {
            this.Resources = new List<Resource>();
            this.HomeworkSubmissions = new List<Homework>();
            this.StudentsEnrolled = new List<StudentCourse>();
        }

        public Course(string v1, string dateTime1, string dateTime2, decimal v2)
        {
            this.Name = v1;
            this.StartDate = dateTime1;
            this.EndDate = dateTime2;
            this.Price = v2;
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
    }
}
