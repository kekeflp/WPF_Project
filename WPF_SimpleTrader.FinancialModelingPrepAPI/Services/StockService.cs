using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.FinancialModelingPrepAPI.Results;
using WPF_SimpleTrader.Domain.Models.API;

namespace WPF_SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockService : IStockService
    {
        // 注意
        // 1.这个官方同时查3大指数需要会员
        // 2.单独股票信息查询和查指数信息使用的是同一个api，返回key相同，value不同

        public async Task<double> GetPrice(string symbol)
        {
            string apikey = "f39e00235a58b78bd6299026e09d244c";
            string uri = $"quote/{symbol}?apikey={apikey}";
            using FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient();
            IEnumerable<StockPriceResult> results = await client.GetJsonResponse<IEnumerable<StockPriceResult>>(uri);

            StockPriceResult result = results.FirstOrDefault();

            // 增加一个结果为0的异常处理
            if (result.Price == 0)
            {
                throw new InvalidSymbolException(symbol);
            }

            return result.Price;
        }

        public async Task<StockResult> GetStock(string symbol)
        {
            string apikey = "f39e00235a58b78bd6299026e09d244c";
            string uri = $"quote/{symbol}?apikey={apikey}";
            using FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient();
            IEnumerable<StockResult> results = await client.GetJsonResponse<IEnumerable<StockResult>>(uri);

            // 增加异常处理
            if (!results.Any())
            {
                throw new InvalidSymbolException(symbol);
            }

            return results.FirstOrDefault();
        }
    }
}

/*

[ {
  "symbol" : "AAPL",
  "name" : "Apple Inc.",
  "price" : 128.10000000,
  "changesPercentage" : 0.20000000,
  "change" : 0.25000000,
  "dayLow" : 127.97440000,
  "dayHigh" : 130.44000000,
  "yearHigh" : 145.09000000,
  "yearLow" : 74.71750000,
  "marketCap" : 2137681559552.00000000,
  "priceAvg50" : 128.30200000,
  "priceAvg200" : 126.05434000,
  "volume" : 81207034,
  "avgVolume" : 102014859,
  "exchange" : "NASDAQ",
  "open" : 129.20000000,
  "previousClose" : 127.85000000,
  "eps" : 4.44900000,
  "pe" : 28.79299000,
  "earningsAnnouncement" : "2021-04-28T16:30:00.000+0000",
  "sharesOutstanding" : 16687599997,
  "timestamp" : 1620266500
} ]

*/