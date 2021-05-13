using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;
using Xunit;

namespace WPF_SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    public class AuthenticationServiceTest
    {
        Mock<IAccountService> _mockAccountSvc;
        Mock<IPasswordHasher<User>> _mockPwdHash;
        AuthenticationService _authenticationSvc;

        /// <summary>
        /// 构造函数相当于Setup/Arrange(预置条件的集合)
        /// </summary>
        public AuthenticationServiceTest()
        {
            _mockAccountSvc = new Mock<IAccountService>();
            _mockPwdHash = new Mock<IPasswordHasher<User>>();
            _authenticationSvc = new AuthenticationService(_mockAccountSvc.Object, _mockPwdHash.Object);
        }

        /*
         * 测试用例的命名一般规则：[方法]_[场景简述]_[预期结果]
         * 3A流程: 场景（预置条件）-动作（操作步骤）-断言（测试结果）
         * 
         * It.IsAny<string>() 类似一些占位符/填充位, 用来替代 不是很重要的参数
         * 如果断言传递的参数非常重要，则还需要It.Is<string>(...)而不是It.IsAny<string>(...) 。
         * 
         */

        [Fact]
        public async Task Login_WithCorrectPasswordForExistingUsername_ResturnsAccountCorrectUsername()
        {
            #region Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            // 虚构用户
            User user = new User() { Username = expectedUsername };
            _mockAccountSvc.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account { AccountHolder = user });
            // 虚构密码
            _mockPwdHash.Setup(s => s.VerifyHashedPassword(user, It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);
            #endregion

            #region Act
            Account account = await _authenticationSvc.Login(expectedUsername, password);
            #endregion

            #region Assert
            string actualUsername = account.AccountHolder.Username;
            Assert.Equal(expectedUsername, actualUsername);
            #endregion
        }

        [Fact]
        public async Task Login_WithIncorrectPasswordForExistingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            // Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            User user = new User() { Username = expectedUsername };
            _mockAccountSvc.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account { AccountHolder = user });
            _mockPwdHash.Setup(s => s.VerifyHashedPassword(user, It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            // Act
            InvalidPasswordException exception = await Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationSvc.Login(expectedUsername, password));

            // Assert
            string actualUsername = exception.Username;
            Assert.Equal(expectedUsername, actualUsername);
        }

        [Fact]
        public async Task Login_WithNonExistingUsername_ThrowsNotFoundExceptionForUsername()
        {
            // Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            User user = new User() { Username = expectedUsername };
            _mockPwdHash.Setup(s => s.VerifyHashedPassword(user, It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            // Act
            UserNotFoundException exception = await Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationSvc.Login(expectedUsername, password));

            // Assert
            string actualUsername = exception.Username;
            Assert.Equal(expectedUsername, actualUsername);
        }

        [Fact]
        public async Task Register_WithPasswordNotMatching_ReturnsPasswordNotMatch()
        {
            string password = "testpassword";
            string confirmPassword = "confirmtestpassword";
            RegistrationResult expected = RegistrationResult.PasswordDoNotMatch;

            // 如果2个密码相同,则注册actual=成功,不相同则返回actual=PasswordDoNotMatch
            RegistrationResult actual = await _authenticationSvc.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            // 断言 注册结果是否和异常相等
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            string email = "test@mail.com";
            // 先要构造一个账户在内存中, 假装查到了这个用户
            _mockAccountSvc.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            // 注册时,内部还会再次查询 (部分非重要参数用指定值还是It.IsAny<string>()的是否有具体影响效果未知,但是可以等价换用,如此处的密码和确认密码)
            RegistrationResult actual = await _authenticationSvc.Register(email, It.IsAny<string>(), "test", "test");

            // 断言 注册结果是否和异常相等
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            string username = "testuser";
            // 先要构造一个账户在内存中, 假装查到了这个用户
            _mockAccountSvc.Setup(s => s.GetByUsername(username)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            // 注册时,内部还会再次查询 (部分非重要参数用指定值还是It.IsAny<string>()的是否有具体影响效果未知,但是可以等价换用,如此处的密码和确认密码)
            RegistrationResult actual = await _authenticationSvc.Register(It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

            // 断言 注册结果是否和异常相等
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Register_WithNonExistingUsernameAndMatchingPasswords_ReturnsSucces()
        {
            RegistrationResult expected = RegistrationResult.Succes;

            RegistrationResult actual = await _authenticationSvc.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // 断言 注册结果是否和异常相等
            Assert.Equal(expected, actual);
        }
    }
}
