﻿using MetaTrader.Connector;
using MewriickTrader.Client.Views;
using MewriickTrader.Core.Trading.Charts;
using MewriickTrader.Core.Trading.Market;
using Microsoft.Practices.Unity;
using MtApi;
using Prism.Unity;
using System.Windows;

namespace MewriickTrader.Client
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<MainPage>(nameof(MainPage));
            Container.RegisterTypeForNavigation<AccountInfo>(nameof(AccountInfo));
            Container.RegisterTypeForNavigation<StatusBar>(nameof(StatusBar));

            Container.RegisterType<MtApiClient>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMarketTimerBars, MetaTraderTimeBarsAdapter>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMarketListener, MetaTraderMarketListenerAdapter>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMarketEventsLogger, ConsoleEventLogger>(new ContainerControlledLifetimeManager());
        }
    }
}
