using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF_SimpleTrader.FinancialModelingPrepAPI;

namespace WPF_SimpleTrader.WPF.HostBuilders
{
    public static class AddFinanceAPIHostBuilderExtensions
    {
        public static IHostBuilder AddFinanceAPI(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string apiKey = context.Configuration.GetValue<string>("FINANCE_API_KEY");
                //string apiKey = ConfigurationManager.AppSettings.Get("FINANCE_API_KEY");
                services.AddSingleton<FinancialModelingPrepHttpClient>(new FinancialModelingPrepHttpClient(apiKey));
            });

            return host;
        }
    }
}
