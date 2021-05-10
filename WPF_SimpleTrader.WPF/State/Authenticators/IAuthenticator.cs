using System;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;
using WPF_SimpleTrader.Domain.Exceptions;

namespace WPF_SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }

        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

        /// <summary>
        /// 获取用户的账户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException">抛出用户不存在的异常</exception>
        /// <exception cref="InvalidPasswordException">抛出密码不正确的异常</exception>
        /// <exception cref="Exception">抛出登录失败的异常</exception>
        Task Login(string username, string password);

        void Logout();

        event Action StateChanged;
    }
}