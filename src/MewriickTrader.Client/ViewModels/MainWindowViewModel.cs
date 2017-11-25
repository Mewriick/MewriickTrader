using MewriickTrader.Client.Views;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace MewriickTrader.Client.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));

            this.regionManager.RegisterViewWithRegion(ApplicationRegions.ContentRegion, typeof(MainPage));
            this.regionManager.RegisterViewWithRegion(ApplicationRegions.MenuRegion, typeof(Menu));
        }
    }
}
