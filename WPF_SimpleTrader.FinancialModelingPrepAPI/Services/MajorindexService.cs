using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models.API;
using WPF_SimpleTrader.Domain.Services;

namespace WPF_SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorindexService : IMajorindexService
    {
        public async Task<Majorindex> GetMajorindices(MajorindexType indexType)
        {
            string apikey = "f39e00235a58b78bd6299026e09d244c";

            #region 封装前
            //string uri = $"https://financialmodelingprep.com/api/v3/quote/{GetUriSuffix(indexType)}?apikey={apikey}";
            //using var client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync(uri);
            //string jsonResponse = await response.Content.ReadAsStringAsync();
            //// 最后结果为数组
            //var result = JsonSerializer.Deserialize<IEnumerable<Majorindex>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            #endregion

            string uri = $"quote/{GetUriSuffix(indexType)}?apikey={apikey}";
            using FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient();
            var results = await client.GetJsonResponse<IEnumerable<Majorindex>>(uri);
            // 数组中就一个对象
            return results.FirstOrDefault();
        }

        private string GetUriSuffix(MajorindexType indexType)
        {
            switch (indexType)
            {
                case MajorindexType.DowJones:
                    return "%5EDJI";
                case MajorindexType.SP500:
                    return "%5EGSPC";
                case MajorindexType.NASDAQ:
                    return "%5EIXIC";
                default:
                    return "%5EDJI";
            }
        }
    }
}

/*
[ {
  "symbol" : "^DJI",
  "name" : "Dow Jones Industrial Average",
  "price" : 33874.85000000,
  "changesPercentage" : -0.54000000,
  "change" : -185.55000000,
  "dayLow" : 33784.96000000,
  "dayHigh" : 33988.75000000,
  "yearHigh" : 34256.75000000,
  "yearLow" : 22789.62000000,
  "marketCap" : null,
  "priceAvg50" : 33430.61000000,
  "priceAvg200" : 30981.97300000,
  "volume" : 376105712,
  "avgVolume" : 183472263,
  "exchange" : "INDEX",
  "open" : 33988.75000000,
  "previousClose" : 34060.40000000,
  "eps" : null,
  "pe" : null,
  "earningsAnnouncement" : null,
  "sharesOutstanding" : null,
  "timestamp" : 1620043778
} ]
 */