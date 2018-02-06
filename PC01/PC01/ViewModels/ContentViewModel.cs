using Newtonsoft.Json;
using PC01.Models;
using PC01.Models.Services;
using PC01.Views.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PC01.ViewModels
{
    public class ContentViewModel : ViewModelBase
    {
        #region BASE_DE_DATOS
        ObservableCollection<Usuario> listado;
        public ObservableCollection<Usuario> Listado
        {
            get
            {
                return listado;
            }
            set
            {
                listado = value;
                this.Notify("Listado");
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
            }
        }

        string correo;
        public string Correo
        {
            get
            {
                return correo;
            }
            set
            {
                correo = value;
                this.Notify("Correo");
            }
        }

        string telefono;
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
                this.Notify("Telefono");
            }
        } 

        void Load()
        {
            var ListUsuarios = _dataService.GetAllUser();
            Listado = new ObservableCollection<Usuario>(ListUsuarios); 

        }

        DataService _dataService;

        #endregion

        
        #region WEB_API

        ObservableCollection<Criptomoneda> listadocripto;
        public ObservableCollection<Criptomoneda> ListadoCripto
        {
            get
            {
                return listadocripto;
            }
            set
            {
                listadocripto = value;
                this.Notify("ListadoCripto");
            }
        }

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                this.Notify("Name");
            }
        }

        string symbol;
        public string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
                this.Notify("Symbol");
            }
        }

        string rank;
        public string Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
                this.Notify("Rank");
            }
        }

        string price_usd;
        public string Price_usd
        {
            get
            {
                return price_usd;
            }
            set
            {
                price_usd = value;
                this.Notify("Price_usd");
            }
        }

        string price_btc;
        public string Price_btc
        {
            get
            {
                return price_btc;
            }
            set
            {
                price_btc = value;
                this.Notify("Price_btc");
            }
        }

        string percent_change_1h;
        public string Percent_change_1h
        {
            get
            {
                return percent_change_1h;
            }
            set
            {
                percent_change_1h = value;
                this.Notify("Percent_change_1h");
            }
        }

        string percent_change_24h;
        public string Percent_change_24h
        {
            get
            {
                return percent_change_24h;
            }
            set
            {
                percent_change_24h = value;
                this.Notify("Percent_change_24h");
            }
        }

        string percent_change_7d;
        public string Percent_change_7d
        {
            get
            {
                return percent_change_7d;
            }
            set
            {
                percent_change_7d = value;
                this.Notify("Percent_change_7d");
            }
        }

        async void Load_WebApi()
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://api.coinmarketcap.com");
                var controller = "/v1/ticker/";
                var response = await cliente.GetAsync(controller);
                var result = await response.Content.ReadAsStringAsync();
                if(!response.IsSuccessStatusCode)
                {
                    _messageService.SendMessage("No se pudo recuperar la información");
                }
                var listadescerializada = JsonConvert.DeserializeObject<List<Criptomoneda>>(result);
                ListadoCripto = new ObservableCollection<Criptomoneda>(listadescerializada);
            }
            catch (Exception E)
            {
                _messageService.SendMessage("No se pudo recuperar la información. Ha ocurrido el siguiente error: " + E);
            }
        }
        #endregion

        MessageService _messageService;

        public ContentViewModel()
        {
            _messageService = new MessageService();
            _dataService = new DataService();
            Load();
            Load_WebApi();
        }
    }
}
