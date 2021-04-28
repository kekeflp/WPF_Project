using CourseManagement.Models;

namespace CourseManagement.Services
{
    public interface ILoginService
    {
        // 1.判断账户是否存在
        // 2.判断密码是否正确
        // 3.取出当前用户
        bool IsUserExist(string userName);
        bool LoginIn(string userName, string password);
        User GetUserInfo(string userName);
    }
}
