using System;
using System.Data;
using System.Data.SqlClient;

namespace Console_QQ.Services
{
    public class DBhelper
    {
        // 链接字符串
        private const string connectionStr = @"server=.\SQLEXPRESS;Database=QQDb;uid=sa;pwd=sa;";

        /// <summary>
        /// 连接对象
        /// </summary>
        private static SqlConnection Con
        {
            get
            {
                var con = new SqlConnection(connectionStr);
                con.Open();
                return con;
            }
        }

        /// <summary>
        /// 获取指令对象
        /// </summary>
        private static SqlCommand Cmd
        {
            get
            {
                return Con.CreateCommand();
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static bool UpdateBySql(string sql)
        {
            var cmd = Cmd;
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
        /// 查，返回首行首列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static object SelectByScalar(string sql)
        {
            var cmd = Cmd;
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
        /// 返回DataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static SqlDataReader SelectByReader(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                cmd.Connection.Close();
                return null;
            }
        }
    }
}
