using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ice_79
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuidelinesPage : ContentPage
    {
        public GuidelinesPage()
        {
            InitializeComponent();
        }
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