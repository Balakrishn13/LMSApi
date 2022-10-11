using System;

namespace LMS.Models
{
    public class AddCourse
    {
        public string Technology { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
    }
}
