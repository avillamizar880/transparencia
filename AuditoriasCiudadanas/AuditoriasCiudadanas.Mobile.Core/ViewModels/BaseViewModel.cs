using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using AuditoriasCiudadanas.Mobile.Core.Models;
using AuditoriasCiudadanas.Mobile.Core.Services;
using Xamarin.Forms.Popups;
using Xamarin.Forms.Navigation;

namespace AuditoriasCiudadanas.Mobile.Core.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IAuthService AuthService;
        protected IPopupsService PopupsService;
        protected INavigationService NavigationService;

        private LoginModel _login;
        public LoginModel Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public bool IsEmailValid(string email)
        {
            try
            {
                var m = new MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}