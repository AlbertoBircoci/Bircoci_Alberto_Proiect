using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Bircoci_Alberto_Proiect.Salon;
using Bircoci_Alberto_Proiect.Data;

namespace Bircoci_Alberto_Proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (Prenotari)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SavePrenotariAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Prenotari)BindingContext;
            await App.Database.DeletePrenotariAsync(slist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiciiPage((Prenotari)this.BindingContext)
            {
                BindingContext = new Servicii()
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Prenotari)BindingContext;
            listView.ItemsSource = await App.Database.GetListServiciisAsync(shopl.ID);
        }
    }
}