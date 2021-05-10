using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using WPF_SimpleTrader.EF;
using WPF_SimpleTrader.EF.Services;
using WPF_SimpleTrader.FinancialModelingPrepAPI.Services;
using WPF_SimpleTrader.WPF.State.Accounts;
using WPF_SimpleTrader.WPF.State.Assets;
using WPF_SimpleTrader.WPF.State.Authenticators;
using WPF_SimpleTrader.WPF.State.Navigators;
using WPF_SimpleTrader.WPF.ViewModels;
using WPF_SimpleTrader.WPF.ViewModels.Factories;

namespace WPF_SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // 需要消费的时候，就到容器中去取
            IServiceProvider serviceProvider = CreateServiceProvider();

            // 在容器中，取回服务的实例
            //IBuyStockService buyStockService = serviceProvider.GetRequiredService<IBuyStockService>();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <returns>返回服务提供者</returns>
        private IServiceProvider CreateServiceProvider()
        {
            /*
             * 我们要尽可能多的，集中所有类的实例到同一个地方来维护。
             * 都去用DI实现他，以下均为重构后：
             */

            // 声明容器-服务集
            IServiceCollection services = new ServiceCollection();

            // 在容器中增加-单例实例
            services.AddSingleton<SimpleTraderDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddSingleton<IDataService<Account>, GenericDataService<Account>>();
            services.AddSingleton<IStockService, StockService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorindexService, MajorindexService>();

            services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();
            services.AddSingleton<BuyViewModel>();
            services.AddSingleton<PortfolioViewModel>();
            services.AddSingleton<AssetSummaryViewModel>();

            services.AddSingleton<HomeViewModel>(services =>
                new HomeViewModel
                (
                    MajorindexViewModel.LoadMajorindexViewModel(services.GetRequiredService<IMajorindexService>()), services.GetRequiredService<AssetSummaryViewModel>()
                )
            );

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => services.GetRequiredService<HomeViewModel>();
            });

            services.AddSingleton<CreateViewModel<BuyViewModel>>(services =>
            {
                return () => services.GetRequiredService<BuyViewModel>();
            });

            services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services =>
            {
                return () => services.GetRequiredService<PortfolioViewModel>();
            });

            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();

            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<AssetStroe>();

            // 范围实例
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            // 构建容器-提供消费使用
            return services.BuildServiceProvider();
        }
    }
}