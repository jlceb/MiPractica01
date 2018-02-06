
using PC01.Views;
using PC01.Views.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PC01
{
	public partial class App : Application
	{
		public App ()
		{
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomeView());
		}

        NavigationService _navigationService;

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            _navigationService = new NavigationService();
            _navigationService.NavigateTo("WelcomeView");
        }
	}
}
