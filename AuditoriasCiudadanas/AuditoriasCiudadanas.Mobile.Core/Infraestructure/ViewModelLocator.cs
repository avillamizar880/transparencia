using AuditoriasCiudadanas.Mobile.Core.Services;
using AuditoriasCiudadanas.Mobile.Core.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms.Popups;

namespace AuditoriasCiudadanas.Mobile.Core.Infraestructure
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IPopupsService, PopupsService>();
            SimpleIoc.Default.Register<IAuthService, AuthService>();

            SimpleIoc.Default.Register<AppMainPageViewModel>();
            SimpleIoc.Default.Register<AppLoginViewModel>();
            SimpleIoc.Default.Register<AppForgotPasswordViewModel>();
            SimpleIoc.Default.Register<AppSignUpViewModel>();
        }

        public AppMainPageViewModel AppMainPageViewModel => SimpleIoc.Default.GetInstance<AppMainPageViewModel>();

        public AppLoginViewModel AppLoginViewModel => SimpleIoc.Default.GetInstance<AppLoginViewModel>();

        public AppForgotPasswordViewModel AppForgotPasswordViewModel => SimpleIoc.Default.GetInstance<AppForgotPasswordViewModel>();

        public AppSignUpViewModel AppSignUpViewModel => SimpleIoc.Default.GetInstance<AppSignUpViewModel>();
    }
}