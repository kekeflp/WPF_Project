using System;

namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : DomainObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
