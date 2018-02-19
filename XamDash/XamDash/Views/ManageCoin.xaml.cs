using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamDash.ViewModels;

namespace XamDash.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageCoin : ContentPage
    {
        CoinDetailViewModel viewModel;
        public ManageCoin()
        {
            InitializeComponent();
        }

        public ManageCoin(CoinDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
               
    }
}