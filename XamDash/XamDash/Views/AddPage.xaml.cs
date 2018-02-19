using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamDash.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
            GridDash gd = new GridDash();

            AddedCoinsList.ItemsSource = gd.myCoins;
            AddedAmountList.ItemsSource = gd.CoinAmounts;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GridDash gd = new GridDash();
            gd.myCoins.Add(ChosenCoin.Text);
            gd.CoinAmounts.Add(2);
            AddedCoinsList.ItemsSource = gd.myCoins;
            AddedAmountList.ItemsSource = gd.CoinAmounts;
        }
    }
}