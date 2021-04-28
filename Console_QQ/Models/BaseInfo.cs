using System;

namespace Console_QQ.Models
{
    public class BaseInfo
    {
        //QQId, NickName, Sex, BornDate, Priovince, City, Address, Phone
        public long QQId { get; set; }
        public string NickName { get; set; }
        public string Sex { get; set; }
        public DateTime BornDate { get; set; }
        public string Priovince { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public QQUser QQUser { get; set; }
    }
}
