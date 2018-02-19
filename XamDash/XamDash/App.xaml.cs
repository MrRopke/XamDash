using XamDash.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamDash
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    //new NavigationPage(new ItemsPage())
                    //{
                    //    Title = "Browse",
                    //    Icon = Device.OnPlatform("tab_feed.png",null,null)
                    //},
                    //new NavigationPage(new AboutPage())
                    //{
                    //    Title = "About",
                    //    Icon = Device.OnPlatform("tab_about.png",null,null)
                    //},
                    //new NavigationPage(new DashPage())
                    //{
                    //    Title = "Dash",
                    //    Icon = Device.OnPlatform("tab_about.png",null,null)
                    //},
                    new NavigationPage(new LoginPage())
                    {
                        Title = "Login",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },

                    new NavigationPage(new GridDash())
                    {
                        Title = "Coin Dash",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },

                    //new NavigationPage(new AddPage())
                    //{
                    //    Title = "Add Coins",
                    //    Icon = Device.OnPlatform("tab_about.png",null,null)
                    //},
                    //new NavigationPage(new Page1())
                    //{
                    //    Title = "Page1",
                    //    Icon = Device.OnPlatform("tab_about.png",null,null)
                    //},
                    new NavigationPage(new ManageCoins())
                    {
                        Title = "Manage",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
