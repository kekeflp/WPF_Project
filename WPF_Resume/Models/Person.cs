using System;
using System.Collections.Generic;

namespace WPF_Resume.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string School { get; set; }
        public string Job { get; set; }
        public string Image { get; set; }
        public string EducationExperience { get; set; }
        public string WorkExperience { get; set; }

        // 1:N
        public List<Experience> Experiences { get; set; }
    }
}