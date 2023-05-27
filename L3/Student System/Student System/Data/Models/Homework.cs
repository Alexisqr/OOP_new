using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Student_System.Data.Models
{

    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public string SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
