using System;
using System.Collections.Generic;
using Console_QQ.Common;
using Console_QQ.Models;

namespace Console_QQ.Services
{
    public class BaseInforService
    {
        private readonly QQUserService _QQUserService = new QQUserService();

        //QQId, NickName, Sex, BornDate, Priovince, City, Address, Phone
        /// <summary>
        /// 添加用户基本信息
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="nickname"></param>
        /// <param name="sex"></param>
        /// <param name="bornDate"></param>
        /// <param name="priovince"></param>
        /// <param name="city"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        public void CreateUserInfo(string pwd, string nickname, string sex, DateTime bornDate, string priovince, string city, string address, string phone)
        {
            var qqUser = _QQUserService.CreateQQUser(pwd);

            // 传参字段判断 略

            var sql = $"insert into baseinfo values({qqUser.QQId},'{nickname}','{sex}','{bornDate.ToFormatDateTimeString()}','{priovince}','{city}','{address}','{phone}')";
            DBhelper.UpdateBySql(sql);
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="qqid"></param>
        /// <returns></returns>
        public BaseInfo GetBaseInfoByQQId(long qqid)
        {
            var sql = $"select QQId, NickName, Sex, BornDate, Priovince, City, [Address], Phone from baseinfo where qqid={qqid}";
            var dr = DBhelper.SelectByReader(sql);
            BaseInfo baseInfo = null;
            if (dr.Read())
            {
                baseInfo = new BaseInfo()
                {
                    QQId = qqid,
                    NickName = dr.GetString(1),
                    Sex = dr.GetString(2),
                    BornDate = dr.GetDateTime(3),
                    Priovince = dr.GetString(4),
                    City = dr.GetString(5),
                    Address = dr.GetString(6),
                    Phone = dr.GetString(7),
                    QQUser = _QQUserService.GetUserByQQid(qqid),
                };
            }
            dr.Close();
            return baseInfo;
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="qqid"></param>
        public void DeleteBaseInfo(long qqid)
        {
            // 联动删除，先删子表，再删主表
            // 先判断qqid是否在baseinfo表中存在
            var sql = $"select count(1) from baseinfo where qqid={qqid}";
            if ((int)DBhelper.SelectByScalar(sql) == 0) throw new ArgumentException("qqid不存在用户基本信息中");
            // 删出子表
            sql = $"delete from baseinfo where qqid ={qqid}";
            // 如果子表删除成功了
            if (DBhelper.UpdateBySql(sql))
            {
                // 再删主表
                _QQUserService.DeleteUser(qqid);
            }
        }

        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <returns></returns>
        public List<BaseInfo> GetAll()
        {
            var sql = $"select QQId, NickName, Sex, BornDate, Priovince, City, [Address], Phone from baseinfo";
            // 模糊查询 where 字段 like '%{字段}%'
            List<BaseInfo> baseInfos = new List<BaseInfo>();
            var dr = DBhelper.SelectByReader(sql);
            if (dr.Read())
            {
                baseInfos.Add(new BaseInfo()
                {
                    QQId = dr.GetInt64(0),
                    NickName = dr.GetString(1),
                    Sex = dr.GetString(2),
                    BornDate = dr.GetDateTime(3),
                    Priovince = dr.GetString(4),
                    City = dr.GetString(5),
                    Address = dr.GetString(6),
                    Phone = dr.GetString(7),
                    QQUser = _QQUserService.GetUserByQQid(dr.GetInt64(0))
                });
            }
            dr.Close();
            return baseInfos;
        }
    }
}
