using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamDash.ViewModels;
using Newtonsoft.Json;
using System.Diagnostics;
using XamDash.Models;
using System.Net.Http;
using System.Reflection;
using System.Collections.ObjectModel;

namespace XamDash.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridDash : ContentPage
    {
        public int UserIdByLogin = 1;

        //Til omregning af priser
        double TotalAmountDKK = 0;
        double TotalOutcomeDKK = 0;
        string TheCoinJson = "";

        //Listen til view
        ObservableCollection<CoinValue> NewCoins = new ObservableCollection<CoinValue>();

        //Bruger coins fra api til lister
        public List<Coinklasse> PrivateCoins = new List<Coinklasse>();
        public List<string> myCoins = new List<string>();        
        public List<double> CoinAmounts = new List<double>();        
        public List<double> CoinBoughtTo = new List<double>();        
        
        //USD kurs
        double USDkurs = 6.18;
        
        //Ved Start
        public GridDash()
        {            
            InitializeComponent();
            GetUserCoinsAsync(UserIdByLogin);            
            
            //UpdateCoinsAsync();            
        }

        private async void MyItemTapped(object sender, ItemTappedEventArgs e)
        {

            var coin = e.Item as CoinValue;
            await Navigation.PushAsync(new ManageCoin(new CoinDetailViewModel(coin))); //pass content if you want to pass the clicked item object to another page
        }

        //async void OnCoinSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var coin = args.SelectedItem as Coinklasse;
        //    if (coin == null)
        //        return;

        //    await Navigation.PushAsync(new ManageCoin(new CoinDetailViewModel(coin)));

        //    // Manually deselect item
        //    MyCoinList.SelectedItem = null;
        //}


        //Få coins fra bruger og overfør data til lister
        public async Task GetUserCoinsAsync(int id)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://newcoinapp.azurewebsites.net/api/coins/{id}";
            var response = await client.GetAsync(address);
            var CoinJson = response.Content.ReadAsStringAsync().Result;
            PrivateCoins = JsonConvert.DeserializeObject<List<Coinklasse>>(CoinJson);

            
            foreach (var item in PrivateCoins)
            {
                myCoins.Add(item.CoinName);
                CoinAmounts.Add(item.CoinAmount);
                CoinBoughtTo.Add(item.CoinBoughtTo);
            }
            
            UpdateCoinsAsync();
        }
        

        //Opret coins i Newcoin listen
        private void CreateCoin(string coinname, float btc, float usd, double myamount, double amountusd , double amountdkk, double coinboughtto, double coinoutcomedkk)
        {
            CoinValue coin = new CoinValue();            
            coin.CoinName = coinname;
            coin.BTC = btc;
            coin.USD = usd;
            coin.MyAmount = myamount;
            coin.AmountUSD = amountusd;
            coin.AmountDKK = amountdkk;
            TotalAmountDKK += amountdkk;
            TotalOutcomeDKK += coinoutcomedkk;
            coin.CoinBoughtTo = coinboughtto;
            coin.CoinOutcomeDKK = coinoutcomedkk;
            NewCoins.Add(coin);
        }

        
        //Hent coin data fra Cryptocompare for angivne coin
        public async Task<string> GetCoinsAsync(string coinname)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"https://min-api.cryptocompare.com/data/price?fsym={coinname}&tsyms=BTC,USD";
            var response = await client.GetAsync(address);
            var CoinJson = response.Content.ReadAsStringAsync().Result;            
            return CoinJson;
        }

        //Update bruger coins og vis i view
        public async Task UpdateCoinsAsync()
        {                        
            for (int i = 0; i < myCoins.Count; i++)
            {                
                TheCoinJson = await GetCoinsAsync(myCoins[i]);
                CoinValue theCoin = JsonConvert.DeserializeObject<CoinValue>(TheCoinJson);
                CreateCoin(myCoins[i], theCoin.BTC, theCoin.USD, CoinAmounts[i], theCoin.USD * CoinAmounts[i], Math.Round((theCoin.USD * CoinAmounts[i] * USDkurs), 2, MidpointRounding.AwayFromZero), CoinBoughtTo[i], (CoinAmounts[i] * theCoin.USD * USDkurs)-(CoinAmounts[i] * CoinBoughtTo[i] * USDkurs) );                            
            }

            BindingContext = this;
            MyCoinList.ItemsSource = NewCoins;
            TotalAmountinDKK.Text = "Total DKK: " + TotalAmountDKK.ToString();
            TotalOutcomeinDKK.Text = "Total Over-/Underskud: " + Math.Round((TotalOutcomeDKK), 2, MidpointRounding.AwayFromZero).ToString();
        }

        //Update knappen i view
        private void Button_Clicked(object sender, EventArgs e)
        {
            TotalAmountDKK = 0;
            TotalOutcomeDKK = 0;
            NewCoins.Clear();
            UpdateCoinsAsync();
        }
    }
}