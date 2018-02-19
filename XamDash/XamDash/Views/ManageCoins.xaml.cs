using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamDash.Models;
using Newtonsoft.Json;
using XamDash.ViewModels;

namespace XamDash.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageCoins : ContentPage
    {
        List<Coinklasse> ManageList = new List<Coinklasse>();
        public ManageCoins()
        {
            InitializeComponent();
            GetCoinsAsync(1);
        }

        private async void MyItemTapped(object sender, ItemTappedEventArgs e)
        {
            var coin = e.Item as Coinklasse;
            await Navigation.PushAsync(new CRUD(new CRUDDetailViewModel(coin)));
        }

        public async void GetCoinsAsync(int id)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://newcoinapp.azurewebsites.net/api/coins/{id}"; //?format=application/json";
            var response = await client.GetAsync(address);
            var CoinJson = response.Content.ReadAsStringAsync().Result;

            ManageList = JsonConvert.DeserializeObject<List<Coinklasse>>(CoinJson);

            BindingContext = this;
            ManageCoinList.ItemsSource = ManageList;
        }
    }
}