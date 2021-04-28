using System;
using System.Configuration;
using System.Data.OleDb;

namespace IndustryApp.Data
{
    public class AccessDbHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["AccessDb"].ConnectionString;

        public static OleDbConnection Connection
        {
            get
            {
                var con = new OleDbConnection(conStr);
                con.Open();
                return con;
            }
        }

        public static OleDbCommand Command { get => Connection.CreateCommand(); }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回增删改是否成功</returns>
        public static bool Update(string sql)
        {
            var cmd = Command;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// 查询-首行首列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回首行首列的值</returns>
        public static object SelectScalar(string sql)
        {
            var cmd = Command;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// 返回DataReader，准备进行转换为对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataReader</returns>
        public static OleDbDataReader SelectDataReader(string sql)
        {
            var cmd = Command;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                cmd.Connection.Close();
                return null;
            }
        }
    }
}
