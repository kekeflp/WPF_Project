using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task<Account> Login(string username, string password);
    }

    public enum RegistrationResult
    {
        Succes,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
    }
}
