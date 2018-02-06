
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PC01.Views.Services
{
    public class NavigationService 
    {
        public async void NavigateTo(string page)
        {
            switch(page)
            {
                case "WelcomeView":
                    await PC01.App.Current.MainPage.Navigation.PushAsync(new WelcomeView());
                    break;
                case "LoginView":
                    await App.Current.MainPage.Navigation.PushAsync(new LoginView());
                    break;
                case "RegisterView":
                    await PC01.App.Current.MainPage.Navigation.PushAsync(new RegisterView());
                    break;
                case "MainView":
                    await PC01.App.Current.MainPage.Navigation.PushAsync(new MainView());
                    break;
                case "ContentView":
                    await PC01.App.Current.MainPage.Navigation.PushAsync(new ContentView());
                    break;
                default:
                    break;
            }
        }

        public NavigationService()
        {
        }
    }
}
