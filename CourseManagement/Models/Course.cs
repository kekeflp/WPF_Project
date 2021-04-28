namespace CourseManagement.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public bool IsPublish { get; set; }
        public string CourseCover { get; set; }
        public string CourseUrl { get; set; }
    }
}
