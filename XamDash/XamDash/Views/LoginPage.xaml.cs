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
	public partial class LoginPage : ContentPage
	{
        public string Usernamet;
        public string Passwordt;

        GridDash gd = new GridDash();

        public LoginPage ()
		{
			InitializeComponent ();            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Login(Username.Text, Password.Text);                       
            //gd.GetUserCoinsAsync(1); 
        }

        public async Task Login(string username, string password)
        {
            
            List<UidClass> Userlist = new List<UidClass>();

            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://newcoinapp.azurewebsites.net/api/users/{username}/{password}";
            var response = await client.GetAsync(address);
            var UserJson = response.Content.ReadAsStringAsync().Result;            
            
            Userlist = JsonConvert.DeserializeObject<List<UidClass>>(UserJson);
            TestId.Text = Userlist[0].Uid.ToString();

            //gd.UserIdByLogin = Userlist[0].Uid;
            //gd.UpdateCoinsAsync(Userlist[0].Uid);
            //gd.GridDash();
            //return Userlist[0].Uid;
        }
    }
}