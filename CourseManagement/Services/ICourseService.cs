using CourseManagement.DTO;
using CourseManagement.Models;
using System.Collections.Generic;

namespace CourseManagement.Services
{
    public interface ICourseService
    {
        List<Course> GetCoursesAll();
        Course GetCourseById(string id);

        List<CourseSerise> GetCourseSerise();
        List<Course> GetCourseTeacherInfo();

    }
}
