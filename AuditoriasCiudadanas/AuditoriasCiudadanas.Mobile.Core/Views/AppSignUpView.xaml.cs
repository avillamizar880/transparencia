using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditoriasCiudadanas.Mobile.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppSignUpView : ContentPage
	{
		public AppSignUpView ()
		{
			InitializeComponent ();

		    BindingContext = App.Locator.AppSignUpViewModel;
        }
	}
}