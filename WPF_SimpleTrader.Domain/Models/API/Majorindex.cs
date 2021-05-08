namespace WPF_SimpleTrader.Domain.Models.API
{
    public class Majorindex
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
    }

    public enum MajorindexType
    {
        DowJones,
        SP500,
        NASDAQ,
    }
}
