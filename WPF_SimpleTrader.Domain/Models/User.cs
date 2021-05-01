using System;

namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
