namespace WPF_SimpleTrader.Domain.Models.API
{
    public class StockResult
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
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