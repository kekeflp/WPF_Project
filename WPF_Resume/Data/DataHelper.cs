using Microsoft.Data.Sqlite;
using System.Configuration;

namespace WPF_Resume.Data
{
    public class DataHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        private static SqliteConnection Con
        {
            get
            {
                var connection = new SqliteConnection(conStr);
                connection.Open();
                return connection;
            }
        }

        private static SqliteCommand Cmd
        {
            get
            {
                return Con.CreateCommand();
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool Update(string sql)
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
        /// 返回首行首列对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
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
        /// DTO关系转对象，返回DataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqliteDataReader ExecuteDataReader(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch
            {
                cmd.Connection.Close();
                return null;
            }
        }
    }
}