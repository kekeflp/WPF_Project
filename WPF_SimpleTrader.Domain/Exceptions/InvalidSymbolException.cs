using System;

namespace WPF_SimpleTrader.Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        public string Symbol { get; set; }
        /// <summary>
        /// 非法的股票代码异常
        /// </summary>
        /// <param name="symbol"></param>
        public InvalidSymbolException(string symbol)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string symbol, string message) : base(message)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string symbol, string message, Exception innerException) : base(message, innerException)
        {
            Symbol = symbol;
        }
    }
}
