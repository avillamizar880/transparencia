using System;
using System.Collections.Generic;
using System.Text;
using AuditoriasCiudadanas.Mobile.Core.Services;
using Xamarin.Forms.Popups;

namespace AuditoriasCiudadanas.Mobile.Core.ViewModels
{
    public class AppForgotPasswordViewModel : BaseViewModel
    {
        public AppForgotPasswordViewModel(INavigationService navigationService, IPopupsService popupService, IAuthService authService)
        {
            NavigationService = navigationService;
            PopupsService = popupService;
            AuthService = authService;
        }
    }
}