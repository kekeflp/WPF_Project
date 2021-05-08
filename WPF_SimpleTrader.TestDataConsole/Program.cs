using System;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Models.API;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using WPF_SimpleTrader.EF.Services;
using WPF_SimpleTrader.FinancialModelingPrepAPI.Services;

namespace WPF_SimpleTrader.TestDataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //DatabaseTest();
            //APITest();
            //BuyStockTest();
            Console.ReadKey();
        }

        static void DatabaseTest()
        {
            IDataService<User> svc = new GenericDataService<User>(new EF.SimpleTraderDbContextFactory());

            Console.WriteLine(svc.Create(new User
            {
                Username = "Tom",
                Email = "Tom@mail.com",
                //Password = "tom123456",
                DateJoined = DateTime.Now
            }
            ));

            Console.WriteLine(svc.Create(new User
            {
                Username = "Cooke",
                Email = "Cooke@mail.com",
                //Password = "Cooke123456",
                DateJoined = DateTime.Now
            }
            ));

            //GET ONE
            Console.WriteLine(svc.GetOne(1).Result);
            //GET ALL
            Console.WriteLine(svc.GetAll().Result);
            //UPDATE
            //REMOVE
            Console.ReadKey();
        }

        static void APITest()
        {
            IMajorindexService mis = new MajorindexService();
            var result = mis.GetMajorindices(MajorindexType.DowJones).Result;
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static void BuyStockTest()
        {
            IStockService stockPriceService = new StockService();
            IDataService<Account> accountService = new GenericDataService<Account>(new EF.SimpleTraderDbContextFactory());
            IBuyStockService buyStockService = new BuyStockService(stockPriceService, accountService);

            Account account = accountService.GetOne(1).Result;
            // x账户 买 AAPL 股票 2份
            buyStockService.BuyStock(account, "AAPL", 2);
        }
    }
}
