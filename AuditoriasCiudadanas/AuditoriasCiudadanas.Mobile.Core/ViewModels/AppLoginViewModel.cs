using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AuditoriasCiudadanas.Mobile.Core.Infraestructure;
using AuditoriasCiudadanas.Mobile.Core.Services;
using Xamarin.Forms;
using Xamarin.Forms.Popups;

namespace AuditoriasCiudadanas.Mobile.Core.ViewModels
{
    public class AppLoginViewModel : BaseViewModel
    {
        public ICommand SignUpCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }

        public AppLoginViewModel(INavigationService navigationService, IPopupsService popupService, IAuthService authService)
        {
            NavigationService = navigationService;
            PopupsService = popupService;
            AuthService = authService;

            LogInCommand = new Command(Login);
            SignUpCommand = new Command(NavigateToSignUp);
            ForgotPasswordCommand = new Command(NavigateToForgotPassword);
        }

        private async void Login()
        {
            await PopupsService.DisplayAlert("Auditorias Ciudadanas", "Starting Login Process", "Ok");
        }

        private void NavigateToForgotPassword()
        {
            NavigationService.NavigateTo(AppPages.AppForgotPassword);
        }

        private void NavigateToSignUp()
        {
            NavigationService.NavigateTo(AppPages.AppSignUp);
        }
    }
}