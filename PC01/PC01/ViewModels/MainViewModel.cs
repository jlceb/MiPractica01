using PC01.Views.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PC01.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        string horaactual;
        public string Horaactual
        {
            get
            {
                return horaactual;
            }
            set
            {
                horaactual = value;
                this.Notify("Horaactual");
            }
        }

        string item1;
        public string Item1
        {
            get
            {
                return item1;
            }
            set
            {
                item1 = value;
                this.Notify("Item1");
            }
        }

        string item2;
        public string Item2
        {
            get
            {
                return item2;
            }
            set
            {
                item2 = value;
                this.Notify("Item2");
            }
        }

        public ICommand AccederDatosCommand
        {
            get;
            set;
        }

        public ICommand CerrarSesionCommand
        {
            get;
            set;
        }

        void AccederDatos()
        {
            _navigationService.NavigateTo("ContentView");
        }

        void CerrarSesion()
        {
            Settings.IsLoggedIn = false;
            _messageService.SendMessage("Adios " + Settings.UserLoggedIn);
            _navigationService.NavigateTo("LoginView");
        }

        NavigationService _navigationService;
        MessageService _messageService;
        

        public MainViewModel()
        {
            DateTime Time = DateTime.Now;
            if (Time.Minute < 10)
                Horaactual = Time.Hour.ToString() + ":0" + Time.Minute.ToString() + ":" + Time.Second.ToString();
            else
                Horaactual = Time.Hour.ToString() + ":" + Time.Minute.ToString() + ":" + Time.Second.ToString();
            Item1 = "CONSULTAR DATOS";
            Item2 = "CERRAR SESIÓN";
            this.AccederDatosCommand = new Command(this.AccederDatos);
            this.CerrarSesionCommand = new Command(this.CerrarSesion);
            _navigationService = new NavigationService();
            _messageService = new MessageService();
        }
    }
}
