using PC01.Models;
using PC01.Models.Services;
using PC01.Views.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PC01.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        string fullname;
        public string Fullname
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
                this.Notify("Fullname");
            }
        }

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

        string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                this.Notify("Phone");
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

        public ICommand SaveCommand
        {
            get;
            set;
        }

        void Save()
        {
            var _usuario = new Usuario
            {
                Nombre = Fullname,
                Correo = Email,
                Telefono = Phone,
                Clave = Password
        };

            _dataService.SaveUser(_usuario);
            _messageService.SendMessage("Registro almacenado");
        }

        MessageService _messageService;
        NavigationService _navigationService;
        DataService _dataService;

        public RegisterViewModel()
        {
            this.SaveCommand = new Command(this.Save);
            _messageService = new MessageService();
            _navigationService = new NavigationService();
            _dataService = new DataService();
        }
    }
}
