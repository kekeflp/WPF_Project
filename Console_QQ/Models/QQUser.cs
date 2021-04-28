using System;

namespace Console_QQ.Models
{
    public class QQUser
    {
        //QQId, Password, LastLogTime, OnlineStateId, Level, OnlineTime
        public long QQId { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginTime { get; set; }
       // public long OnlineStateId { get; set; }

        public int OnlineTime { get; set; } = 1;

        public string Level
        {
            get
            {
                if (OnlineTime < 5) return "⭐";
                if (OnlineTime < 32) return "🌙";
                if (OnlineTime < 320) return "🌙🌙";
                return "☀";
            }
        }
    }
}
