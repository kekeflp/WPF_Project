using CourseManagement.Common;
using CourseManagement.Models;
using System;

namespace CourseManagement.Services
{
    public class LoginService : ILoginService
    {
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>存在或不存在</returns>
        public bool IsUserExist(string userName)
        {
            string sql = $"select count(*) from Users Where userName = '{userName}';";
            return (int)AccessDbHelper.SelectForScalar(sql) > 0;
        }

        /// <summary>
        /// 判断是否登陆成功
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool LoginIn(string userName, string password)
        {
            if (IsUserExist(userName))
            {
                string sql = $"select count(*) from Users Where userName = '{userName}' and password = '{MarkMD5.GeneratePwdMD5(userName, password)}';";
                return (int)AccessDbHelper.SelectForScalar(sql) > 0;
            }
            return false;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>返回用户信息</returns>
        public User GetUserInfo(string userName)
        {
            string sql = $"select * from Users Where userName = '{userName}';";
            var dr = AccessDbHelper.SelectForDataReader(sql);
            User user = new User();
            while (dr.Read())
            {
                user.UserID = dr["UserID"].ToString();
                user.UserName = dr["UserName"].ToString();
                user.RealName = dr["RealName"].ToString();
                user.Password = dr["Password"].ToString();
                user.Avatar = dr["Avatar"].ToString();
                user.Gender = Convert.ToInt32(dr["Gender"]);
                user.IsValidation = (bool)dr["IsValidation"];
                user.IsCanLogin = (bool)dr["IsCanLogin"];
                user.IsTeacher = (bool)dr["IsTeacher"];
            }
            return user;
        }
    }
}