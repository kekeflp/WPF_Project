using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using WPF_SimpleTrader.EF.Services;
using WPF_SimpleTrader.FinancialModelingPrepAPI.Services;

namespace WPF_SimpleTrader.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IAccountService, AccountService>();
                services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

                services.AddSingleton<IDataService<Account>, GenericDataService<Account>>();
                services.AddSingleton<IStockService, StockService>();
                services.AddSingleton<IBuyStockService, BuyStockService>();
                services.AddSingleton<ISellStockService, SellStockService>();
                services.AddSingleton<IMajorindexService, MajorindexService>();
            });

            return host;
        }
    }
}
