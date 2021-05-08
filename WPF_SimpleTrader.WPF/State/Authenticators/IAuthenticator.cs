using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;

namespace WPF_SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task<bool> Login(string username, string password);
        void Logout();
    }
}