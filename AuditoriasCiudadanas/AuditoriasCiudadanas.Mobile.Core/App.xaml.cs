using System.Globalization;
using System.Reflection;
using AuditoriasCiudadanas.Mobile.Core.Infraestructure;
using AuditoriasCiudadanas.Mobile.Core.Services;
using AuditoriasCiudadanas.Mobile.Core.ViewModels;
using AuditoriasCiudadanas.Mobile.Core.Views;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.ToolKit.Extensions;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AuditoriasCiudadanas.Mobile.Core
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        public App()
        {
            InitializeComponent();
            
            ImageResourceExtension.InitImageResourceExtension("Assets.Images", typeof(App).GetTypeInfo().Assembly);
            TranslateExtension.InitTranslateExtension("Assets.Localization.Resources", CultureInfo.CurrentCulture, typeof(App).GetTypeInfo().Assembly);

            INavigationService navigationService;

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                // Setup navigation service:
                navigationService = new NavigationService();

                // Configure pages:
                navigationService.Configure(AppPages.AppMainPage, typeof(AppMainPageView));
                navigationService.Configure(AppPages.AppLogin, typeof(AppLoginView));
                navigationService.Configure(AppPages.AppForgotPassword, typeof(AppForgotPasswordView));
                navigationService.Configure(AppPages.AppSignUp, typeof(AppSignUpView));

                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register(() => navigationService);
            }
            else
                navigationService = SimpleIoc.Default.GetInstance<INavigationService>();

            var firstPage = new NavigationPage(new AppMainPageView());
            navigationService.Initialize(firstPage);

            MainPage = firstPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
