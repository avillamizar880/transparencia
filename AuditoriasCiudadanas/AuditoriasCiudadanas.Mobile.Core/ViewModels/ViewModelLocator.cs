using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;
using Xamarin.Forms.Popups;

namespace AuditoriasCiudadanas.Mobile.Core.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IPopupsService, PopupsService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            SimpleIoc.Default.Register<AppMainPageViewModel>();
        }

        public AppMainPageViewModel AppMainPageViewModel => SimpleIoc.Default.GetInstance<AppMainPageViewModel>();
    }
}