using PC01.Views;
using PC01.Views.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PC01.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        string mensaje;
        public string Mensaje
        {
            get
            {
                return mensaje;
            }
            set
            {
                mensaje = value;
                this.Notify("Mensaje");
            }
        }

        string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                this.Notify("Nombre");
                Mensaje = Nombre + " bienvenido(a) a mi práctica de conocimientos";
            }
        }

        public ICommand IniciarCommand
        {
            get;
            set;
        }

         void Iniciar()
        {
            _navigationService.NavigateTo("LoginView");
        }

        NavigationService _navigationService;

        public WelcomeViewModel()
        {
            this.IniciarCommand = new Command(this.Iniciar);
            _navigationService = new NavigationService();
        }
    }
}
