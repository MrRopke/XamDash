using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamDash.Models;
using Newtonsoft.Json;

namespace XamDash.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public List<Coinklasse> TheList = new List<Coinklasse>(); 

        public Page1()
        {
            InitializeComponent();
            TestLabel.Text = "Hej";
            GetCoinsAsync();
            //CreateCoin(1, "btc", 2, 1, 1);
            //CreateCoin(1, "EOS", 2, 1, 1);
            //CoinView.ItemsSource = TheList;
        }


        public async void GetCoinsAsync()
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://newcoinapp.azurewebsites.net/api/coins"; //?format=application/json";
            var response = await client.GetAsync(address);
            var CoinJson = response.Content.ReadAsStringAsync().Result;

            TheList = JsonConvert.DeserializeObject<List<Coinklasse>>(CoinJson);
            
            BindingContext = this;
            CoinView.ItemsSource = TheList;            
        }

        //list = JsonConvert.DeserializeObject<List<StudentListClass.RootObject>>(JsonString)




    }
}