using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;

namespace AuditoriasCiudadanas.Mobile.Core.ViewModels
{
    public class AppMainPageViewModel : BaseViewModel
    {
        public ICommand NavigateToLoginCommand { get; set; }

        public AppMainPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateToLoginCommand = new Command(NavigateToLogin);
        }

        private async void NavigateToLogin()
        {
            await NavigationService.NavigateTo("AppLoginView");
        }
    }
}