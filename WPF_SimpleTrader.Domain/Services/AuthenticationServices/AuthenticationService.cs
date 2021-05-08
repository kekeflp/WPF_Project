using System;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using Microsoft.AspNetCore.Identity;
using WPF_SimpleTrader.Domain.Exceptions;

namespace WPF_SimpleTrader.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IAccountService _accountService;
        private readonly IPasswordHasher<User> _hasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher<User> passwordHasher)
        {
            _accountService = accountService;
            _hasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account account = await _accountService.GetByUsername(username);
            if (account == null) throw new UserNotFoundException(username);

            var result = _hasher.VerifyHashedPassword(account.AccountHolder, account.AccountHolder.PasswordHash, password);
            if (result != PasswordVerificationResult.Success) throw new InvalidPasswordException(username, password);
            return account;
        }


        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Succes;

            if (password != confirmPassword) { result = RegistrationResult.PasswordDoNotMatch; }

            Account account_email = await _accountService.GetByEmail(email);
            if (account_email != null) { result = RegistrationResult.EmailAlreadyExists; }

            Account account_username = await _accountService.GetByUsername(username);
            if (account_username != null) { result = RegistrationResult.UsernameAlreadyExists; }

            if (result == RegistrationResult.Succes)
            {
                User user = new User
                {
                    Email = email,
                    Username = username,
                    DateJoined = DateTime.Now,
                };
                user.PasswordHash = _hasher.HashPassword(user, password);

                Account account = new Account()
                {
                    AccountHolder = user
                };
                await _accountService.Create(account);
            }

            return result;
        }
    }
}
