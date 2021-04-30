using CourseManagement.Common;
using CourseManagement.Models;
using System.Collections.Generic;

namespace CourseManagement.Services
{
    public class UserSevice : IUserSevice
    {
        public List<string> GetTeacher()
        {
            string sql = "select RealName from Users Where IsTeacher = true;";
            var dr = AccessDbHelper.SelectForDataReader(sql);

            List<string> teachers = new List<string>();
            while (dr.Read())
            {
                string TeacherName = dr["RealName"].ToString();
                teachers.Add(TeacherName);
            }
            return teachers;
        }
    }
}
