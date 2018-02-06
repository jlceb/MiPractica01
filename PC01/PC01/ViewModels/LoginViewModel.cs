using PC01.Models;
using PC01.Models.Services;
using PC01.Views.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static Android.Support.V7.Widget.RecyclerView.LayoutManager;

namespace PC01.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                this.Notify("Email");
            }
        }

        string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                this.Notify("Password");
            }
        }

        public ICommand LoginCommand
        {
            get;
            set;
        }

        public ICommand RegisterCommand
        {
            get;
            set;
        }

        void Login()
        {
            if (Settings.IsLoggedIn == false)
            {
                sw = 0;
                U = _dataService.GetUser(this.Email);
                if ((this.Email == "admin" && this.Password == "123" )) 
                {
                    sw = 1; 
                }
                else if  (U != null)
                {
                    sw = 1;
                }
                if (sw == 1)
                {
                    Settings.IsLoggedIn = true;
                    Settings.UserLoggedIn = this.Email;
                    _messageService.SendMessage("Usted se ha validado como <" + this.Email + ">");
                    _navigationService.NavigateTo("MainView");
                }
                else
                {
                    _messageService.SendMessage("Credenciales inválidas");
                }
            }
            else
                _navigationService.NavigateTo("MainView");
        }

        void Register()
        {
            _navigationService.NavigateTo("RegisterView");
        }

        int sw;
        Usuario U;
        DataService _dataService;
        MessageService _messageService;
        NavigationService _navigationService;

        public LoginViewModel()
        {
            this.LoginCommand = new Command(this.Login);
            this.RegisterCommand = new Command(this.Register);
            U = new Usuario();
            _dataService = new DataService();
            _messageService = new MessageService();
            _navigationService = new NavigationService();
        }
    }
}
