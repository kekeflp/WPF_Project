using System;
using Console_QQ.Common;
using Console_QQ.Models;

namespace Console_QQ.Services
{
    public class QQUserService
    {
        // 登录
        // 查看用户信息
        // 更新用户信息-更新在线天数，更新用户等级
        // 添加用户
        // 删除用户

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="qqId">用户号</param>
        /// <param name="pwd">密码</param>
        public bool LoginUser(long qqId, string pwd)
        {
            pwd = pwd.Trim();
            var sql = $"select count(0) from qquser where QQId={qqId} and [Password]='{pwd}'";
            return (int)DBhelper.SelectByScalar(sql) == 1;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <returns>QQUser</returns>
        public QQUser CreateQQUser(string pwd)
        {
            pwd = pwd.Trim();
            if (pwd.Length < 6) throw new ArgumentException("密码不能少于6位");

            var qqId = RandomQQId();
            var loginTime = DateTime.Now;
            var onlineTime = 0;
            var sql = $"insert into qquser values({qqId},'{pwd}',{loginTime.ToFormatDateString()},{onlineTime})";
            DBhelper.UpdateBySql(sql);
            return new QQUser()
            {
                QQId = qqId,
                Password = pwd,
                LastLoginTime = loginTime,
                OnlineTime = onlineTime
            };
        }

        /// <summary>
        /// 获取随机账号ID
        /// </summary>
        /// <returns></returns>
        private long RandomQQId()
        {
            var rdm = new Random();
            while (true)
            {
                var id = rdm.Next(100000, 999999);
                var sql = $@"select count(0) from qquser where QQId={id}";
                if ((int)DBhelper.SelectByScalar(sql) == 0) return id;
            }
        }

        public void DeleteUser(long qqId)
        {
            var sql = $"select count(0) from qquser where QQId={qqId}";
            if ((int)DBhelper.SelectByScalar(sql) != 1) throw new ArgumentException("用户不存在！");
            sql = $"delete from qquser where QQId={qqId}";
            DBhelper.UpdateBySql(sql);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="qqId">账户号</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        public void UpdateQQUserPwd(long qqId, string oldPwd, string newPwd)
        {
            oldPwd = oldPwd.Trim();
            newPwd = newPwd.Trim();
            if (!LoginUser(qqId, oldPwd)) throw new ArgumentException("用户名或密码错误！");

            var sql = $"update qquser set [Password]='{newPwd}' where QQId={qqId}";
            DBhelper.UpdateBySql(sql);
        }

        public void UpdateQQUserOnlineTime(long qqId, int time)
        {
            // 判断时间是否正确，用户是否存在
            var sql = $"select count(0) from qquser where QQId={qqId}";
            if (time <= 0) throw new ArgumentException("输入的时常不正确");
            if ((int)DBhelper.SelectByScalar(sql) != 1) throw new ArgumentException("用户不存在！");

            sql = $"update qquser set [onlinetime]=[onlinetime]+{time} where QQId={qqId}";
            DBhelper.UpdateBySql(sql);
        }

        public QQUser GetUserByQQid(long qqId)
        {
            var sql = $"select QQId,[Password],LastLoginTime,OnlineTime from qquser where QQId={qqId}";
            var dr = DBhelper.SelectByReader(sql);
            var qquser = new QQUser();
            if (dr.Read())
            {
                qquser.QQId = qqId;
                qquser.Password = dr.GetString(1);
                qquser.LastLoginTime = dr.GetDateTime(2);
                qquser.OnlineTime = dr.GetInt32(3);
            }
            dr.Close();
            return qquser;
        }
    }
}
