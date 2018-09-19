using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Mobile.Core.Infraestructure;
using Xamarin.Forms;

namespace AuditoriasCiudadanas.Mobile.Core.Services
{
    public interface INavigationService
    {
        void GoBack();

        void NavigateTo(AppPages pageKey);

        void NavigateTo(AppPages pageKey, object parameter);

        void Configure(AppPages pageKey, Type pageType);

        void Initialize(NavigationPage navigation);
    }
}