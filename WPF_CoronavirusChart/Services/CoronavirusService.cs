using WPF_CoronavirusChart.Models;
using WPF_CoronavirusChart.Services.ApiModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPF_CoronavirusChart.Services
{
    class CoronavirusService : ICoronavirusService
    {
        public async Task<IEnumerable<CoronavirusCountry>> GetCoronavirusCountriesAsync(int n)
        {
            using (HttpClient client = new HttpClient())
            {
                // 获取所有的返回信息，包含Headers(状态码、版本等等)和Message Body
                var apiResponse = await client.GetAsync(@"https://corona.lmao.ninja/v2/countries?sort=cases");

                // 从Message Body中获取文本
                var jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                //返回的结果为json协议，需要反序列化为类, 并且忽略属性的大小写 , 返回一个国家集合
                List<APICoronavirusCountry> apiCountries = JsonSerializer.Deserialize<List<APICoronavirusCountry>>(jsonResponse,
                     new JsonSerializerOptions()
                     {
                         PropertyNameCaseInsensitive = true,
                     });

                // 从返回的api结果集合中,找出每一个国家对象，然后每个对象实例化后逐一赋值到对应的属性上
                return apiCountries.Take(n).Select(c => new CoronavirusCountry()
                {
                    Country = c.Country,
                    Cases = c.Cases,
                    FlagUrl = c.APICountryInfo.Flag
                });

            }
        }
    }
}