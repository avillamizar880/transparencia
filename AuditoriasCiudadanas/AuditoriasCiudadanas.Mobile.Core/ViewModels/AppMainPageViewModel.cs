using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AuditoriasCiudadanas.Mobile.Core.Infraestructure;
using AuditoriasCiudadanas.Mobile.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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

        private void NavigateToLogin()
        {
            NavigationService.NavigateTo(AppPages.AppLogin);
        }
    }
}