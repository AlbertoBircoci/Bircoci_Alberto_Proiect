using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Bircoci_Alberto_Proiect.Salon;

namespace Bircoci_Alberto_Proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiciiPage : ContentPage
    {
        Prenotari sl;
        public ServiciiPage(Prenotari slist)
        {
            InitializeComponent();
            sl = slist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var servicii = (Servicii)BindingContext;
            await App.Database.SaveProductAsync(servicii);
            listView.ItemsSource = await App.Database.GetServiciisAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var servicii = (Servicii)BindingContext;
            await App.Database.DeleteProductAsync(servicii);
            listView.ItemsSource = await App.Database.GetServiciisAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetServiciisAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Servicii p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Servicii;
                var lp = new ListServicii()
                {
                    PrenotariID = sl.ID,
                    ServiciiD = p.ID
                };
                await App.Database.SaveListServiciiAsync(lp);
                p.ListServiciis = new List<ListServicii> { lp };
                await Navigation.PopAsync();
            }
        }
}
}