using System.Globalization;
using System.Reflection;
using AuditoriasCiudadanas.Mobile.Core.ViewModels;
using AuditoriasCiudadanas.Mobile.Core.Views;
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

            var appMainPage = new NavigationPage(new AppMainPageView());
            MainPage = appMainPage;
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
