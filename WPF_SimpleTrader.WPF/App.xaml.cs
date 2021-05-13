using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using WPF_SimpleTrader.EF;
using WPF_SimpleTrader.EF.Services;
using WPF_SimpleTrader.FinancialModelingPrepAPI.Services;
using WPF_SimpleTrader.WPF.HostBuilders;
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
        readonly IHost _host;
        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .AddConfiguration()
                .AddFinanceAPI()
                .AddDbContext()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddViews();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // 需要消费的时候，就到容器中去取
            //IServiceProvider serviceProvider = CreateServiceProvider();
            // 在容器中，取回服务的实例
            //IBuyStockService buyStockService = serviceProvider.GetRequiredService<IBuyStockService>();

            _host.Start();

            //SimpleTraderDbContextFactory contextFactory = _host.Services.GetRequiredService<SimpleTraderDbContextFactory>();
            //using (SimpleTraderDbContext context = contextFactory.CreateDbContext())
            //{
            //    context.Database.Migrate();
            //}

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
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


            // 构建容器-提供消费使用
            return services.BuildServiceProvider();
        }
    }
}