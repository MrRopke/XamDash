using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using System.Diagnostics;
using XamDash.Models;
using System.Net.Http;
using System.Reflection;
using System.Collections.ObjectModel;

namespace XamDash.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashPage : ContentPage
    {

        string TheCoinJson = "";

        string[] myCoins = new string[] {"BTC", "EOS", "TRX", "MANA", "XMR"};

        string[] MyCoinsValues = new string[5];

        public List<string> MyCoinsValues2 = new List<string>();

        //ObservableCollection<Coins> coins = new ObservableCollection<Coins>();

        double USDkurs = 6.18;


        public DashPage()
        {
            InitializeComponent();
            UpdateMyCoins();
            //MineCoinsArray.ItemsSource = MyCoinsValues;


            CoinButton.Clicked += async (s, e) => {
                var code = CoinCode.Text;


                //CoinInfo.Text += await GetCoinsAsync(code);
                TheCoinJson = await GetCoinsAsync(code);



                CoinValue theCoin = JsonConvert.DeserializeObject<CoinValue>(TheCoinJson);

                CoinValue c = new CoinValue();                        

                c = new CoinValue { CoinName = code, USD = theCoin.USD, BTC = theCoin.BTC };
               

                CoinInfo.Text += String.Format("Coin Name: {0} USD: {1} BTC: {2}", code, theCoin.USD, theCoin.BTC);

                //CoinInfo.Text += "Coinname: " + code + " USD: " + theCoin.TRX.USD + " BTC: " + theCoin.TRX.BTC;
            };

            


            //airportButton.Clicked += async (s, e) =>
            //{                
            //    //CoinInfo.Text = await GetCoinsAsync();
            //    TheCoinJson = await GetCoinsAsync();

            //    //Coin.Rootobject theCoin = JsonConvert.DeserializeObject<Coin.Rootobject>(TheCoinJson);
            //    //var Items = JsonConvert.DeserializeObject<List<Coin>>(TheCoinJson);
            //    //ListView1.ItemsSource = Items;

            //    Coin theCoin = JsonConvert.DeserializeObject<Coin>(TheCoinJson);              


            //    CoinInfo.Text = "USD: " + theCoin.USD.ToString() + "BTC: " + theCoin.BTC;
            //};

        }


        public async Task<string> GetCoinsAsync(string code)
        {

            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"https://min-api.cryptocompare.com/data/price?fsym={code}&tsyms=BTC,USD"; //?format=application/json";

            var response = await client.GetAsync(address);

            var CoinJson = response.Content.ReadAsStringAsync().Result;

            CoinValue theCoin = JsonConvert.DeserializeObject<CoinValue>(CoinJson);


            return CoinJson;

        }        

        public void UpdateMyCoins()
        {
            MyCoinsValues2.Clear();

            
            CoinValue CV = new CoinValue();

            CoinButton.Clicked += async (s, e) => {

                    for (int i = 0; i < myCoins.Length; i++)
                    {
                        TheCoinJson = await GetCoinsAsync(myCoins[i]);

                        CoinValue theCoin = JsonConvert.DeserializeObject<CoinValue>(TheCoinJson);

                        //Array
                        MyCoinsValues[i] = String.Format("Coin Name: {0} USD: {1}", myCoins[i], theCoin.USD);

                        //List
                        MyCoinsValues2.Add(String.Format("Coin: {0}\t USD: {1} $\t DKK: {2} Kr.", myCoins[i], theCoin.USD, (theCoin.USD*USDkurs).ToString("0.##")));

                        //Add to property array
                        CV = new CoinValue { CoinName = myCoins[i], BTC = theCoin.BTC, USD = theCoin.USD };

                        CoinInfo.Text += String.Format("Coin Name: {0} USD: {1}", myCoins[i], theCoin.USD);
                    }

                    
                    MineCoinsArray.ItemsSource = MyCoinsValues2;
                    

                };
            
        }



    }
}