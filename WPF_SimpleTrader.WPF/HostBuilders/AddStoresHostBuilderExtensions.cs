using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF_SimpleTrader.WPF.State.Accounts;
using WPF_SimpleTrader.WPF.State.Assets;
using WPF_SimpleTrader.WPF.State.Authenticators;
using WPF_SimpleTrader.WPF.State.Navigators;

namespace WPF_SimpleTrader.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
                services.AddSingleton<AssetStroe>();
            });

            return host;
        }
    }
}