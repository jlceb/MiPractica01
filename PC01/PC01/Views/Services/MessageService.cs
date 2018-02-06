
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PC01.Views.Services
{
    public class MessageService
    {

        public async void SendMessage(string message)
        {
            await PC01.App.Current.MainPage.DisplayAlert("Notificación", message, "ACEPTAR");
        }

        public MessageService()
        {
        }
    }
}
