using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace CourseManagement.Common
{
    public class AccessDbHelper
    {
        private static readonly string conString = ConfigurationManager.ConnectionStrings["CMS"].ConnectionString;

        private static OleDbConnection Con
        {
            get
            {
                var con = new OleDbConnection(conString);
                con.Open();
                return con;
            }
        }
        private static OleDbCommand Cmd { get => Con.CreateCommand(); }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回增删改是否成功</returns>
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
        /// 查询-首行首列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回首行首列的值</returns>
        public static object SelectForScalar(string sql)
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
        /// 返回DataReader，准备进行转换为对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataReader</returns>
        public static OleDbDataReader SelectForDataReader(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                cmd.Connection.Close();
                return null;
            }
        }
    }
}
