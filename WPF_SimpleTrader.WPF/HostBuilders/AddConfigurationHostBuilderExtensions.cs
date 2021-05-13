using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WPF_SimpleTrader.WPF.HostBuilders
{
    public static class AddConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("Appsettings.json");
                c.AddEnvironmentVariables();
            });
            return host;
        }
    }
}
