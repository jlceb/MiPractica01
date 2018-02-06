using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PC01.Views.Services;

namespace PC01.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent();
            Settings.IsLoggedIn = false;
            this.Email.IsEnabled = true;
            this.Password.IsEnabled = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Email.Text = "";
            this.Password.Text = "";
            if (Settings.IsLoggedIn==true)
            {
                this.Email.IsEnabled = false;
                this.Password.IsEnabled = false;
            }
            else
            {
                this.Email.IsEnabled = true;
                this.Password.IsEnabled = true;
            }
        }
    }
}