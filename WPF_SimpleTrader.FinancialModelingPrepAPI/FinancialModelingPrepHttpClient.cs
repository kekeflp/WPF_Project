using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPF_SimpleTrader.FinancialModelingPrepAPI
{
    /// <summary>
    /// 封装自定义的HttpClient类
    /// </summary>
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        public FinancialModelingPrepHttpClient()
        {
            base.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }

        /// <summary>
        /// 获取泛型类型的响应实例
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="uri">Uri地址</param>
        /// <returns>返回泛型类对象的实例</returns>
        public async Task<T> GetJsonResponse<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
