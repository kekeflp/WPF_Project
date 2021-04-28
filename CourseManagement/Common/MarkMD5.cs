using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CourseManagement.Common
{
    public class MarkMD5
    {
        public static string GeneratePwdMD5(string userName, string password)
        {
            using var md5 = MD5.Create();
            // 把要加密的内容转成字节数组
            string salt = "helloworld";
            var newString = userName + password + salt;
            byte[] buffer = Encoding.Default.GetBytes(newString);
            // 进行MD5计算
            var md5Value = md5.ComputeHash(buffer);
            // byte[] 转 string
            string result = null;
            for (int i = 0; i < md5Value.Count(); i++)
            {
                result += md5Value[i].ToString("x2");
            }
            return result;
        }
    }
}
