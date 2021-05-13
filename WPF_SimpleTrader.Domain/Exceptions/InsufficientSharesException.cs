using System;

namespace WPF_SimpleTrader.Domain.Exceptions
{
    public class InsufficientSharesException : Exception
    {
        public string Symbol { get; }
        public int AccountShares { get; }
        public int RequiredShares { get; }

        /// <summary>
        /// 股票股份不足的异常
        /// </summary>
        /// <param name="symbol">股票代码</param>
        /// <param name="accountShares">账户拥有的股份数</param>
        /// <param name="requiredShares">需购买的股份数</param>
        public InsufficientSharesException(string symbol, int accountShares, int requiredShares)
        {
            Symbol = symbol;
            AccountShares = accountShares;
            RequiredShares = requiredShares;
        }

        public InsufficientSharesException(string symbol, int accountShares, int requiredShares, string message) : base(message)
        {
            Symbol = symbol;
            AccountShares = accountShares;
            RequiredShares = requiredShares;
        }

        public InsufficientSharesException(string symbol, int accountShares, int requiredShares, string message, Exception innerException) : base(message, innerException)
        {
            Symbol = symbol;
            AccountShares = accountShares;
            RequiredShares = requiredShares;
        }
    }
}