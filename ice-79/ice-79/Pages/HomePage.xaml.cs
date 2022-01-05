using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ice_79
{
    /// <summary>
    /// This is the first page of the application
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the home page
        /// </summary>
        private async void LoginViaLicense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PublicHome());
        }

        /// <summary>
        /// Navigates to the Guidelines page
        /// </summary>
        private async void GuidelinesPageOpenLabel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuidelinesPage());
        }

        /// <summary>
        /// As this application's master developer, I'm asking you to not change this page's note. Write your name in other pages if you like
        /// </summary>
        private async void InstagarmOpen_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.instagram.com/taiwbi/", new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.FromHex("#0A1646"),
                PreferredControlColor = Color.FromHex("#F0F0F0"),
            });
        }
    }
}