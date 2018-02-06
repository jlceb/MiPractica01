using PC01.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PC01.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentView : TabbedPage
	{
		public ContentView ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var _dataService = new DataService();
            Milista.ItemsSource = _dataService.GetAllUser();    
        }
    }
}