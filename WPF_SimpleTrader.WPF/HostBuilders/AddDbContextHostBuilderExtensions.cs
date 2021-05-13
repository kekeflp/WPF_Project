using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF_SimpleTrader.EF;

namespace WPF_SimpleTrader.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string conString = context.Configuration.GetConnectionString("default");
                //string conString = context.Configuration.GetConnectionString("sqlite");

                services.AddSingleton<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(conString));
                services.AddDbContext<SimpleTraderDbContext>(o => o.UseSqlite(conString));
            });
            return host;
        }
    }
}
