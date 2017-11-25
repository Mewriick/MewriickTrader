using MetaTrader.Connector;
using MewriickTrader.Client.Views;
using MewriickTrader.Core.Trading;
using Microsoft.Practices.Unity;
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

            Container.RegisterType<IChartListener, MetaTraderChartAdapter>(new ContainerControlledLifetimeManager());
        }
    }
}
