namespace CourseManagement.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public bool IsValidation { get; set; }
        public bool IsCanLogin { get; set; }
        public bool IsTeacher { get; set; }
        public string ValidationCode { get; set; }
    }
}
