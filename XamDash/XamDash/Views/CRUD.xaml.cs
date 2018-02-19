using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamDash.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace XamDash.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUD : ContentPage
    {
        CRUDDetailViewModel viewModel;
        public CRUD()
        {
            InitializeComponent();
        }

        public CRUD(CRUDDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}