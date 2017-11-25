using MewriickTrader.Client.Views;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace MewriickTrader.Client.ViewModels
{
    public class MenuViewModel
    {
        public ICommand NavigateToMainPageCommand { get; private set; }

        public ICommand NavigateToAccountInfoPageCommand { get; private set; }

        private readonly IRegionManager regionManager;

        public MenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));


            NavigateToMainPageCommand = new DelegateCommand(() => NavigateTo(nameof(MainPage)));
            NavigateToAccountInfoPageCommand = new DelegateCommand(() => NavigateTo(nameof(AccountInfo)));
        }

        private void NavigateTo(string url)
        {
            regionManager.RequestNavigate(ApplicationRegions.ContentRegion, url);
        }
    }
}
