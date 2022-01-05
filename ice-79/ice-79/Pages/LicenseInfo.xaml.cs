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
    public partial class LicenseInfo : ContentPage
    {
        public LicenseInfo()
        {
            InitializeComponent();
            DeviceID.Text = "Your device ID: " + LicenseData.DeviceID;
        }
        /// <summary>
        /// Close this page and go back to the last page
        /// </summary>
        private async void CloseButt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Copy Bitcoin's donate address
        /// </summary>
        private async void BTC_Tapped(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync("1M8qEG2QDyHeoezuw3uymhjrjAe4zYoYwb");
            PopUPData.Title = "Done";
            PopUPData.Shortexplan = "Seccusfully";
            PopUPData.Longexplan = $"Bitcoin Address copied to clipboard";
            await Navigation.PushAsync(new Pop_Up());
        }

        /// <summary>
        /// Copy BCH's donate address
        /// </summary>
        private async void BCH_Tapped(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync("bitcoincash:qrl7xtzdfzhkuy7maw5q70j9h4qdfwcf3u3nse8klf");
            PopUPData.Title = "Done";
            PopUPData.Shortexplan = "Seccusfully";
            PopUPData.Longexplan = $"Bitcoin Cash Address copied to clipboard";
            await Navigation.PushAsync(new Pop_Up());
        }

        /// <summary>
        /// Copy ETH's donate address
        /// </summary>
        private async void ETH_Tapped(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync("0x453F08Ca70f840462DCCdbC7028632878119181f");
            PopUPData.Title = "Done";
            PopUPData.Shortexplan = "Seccusfully";
            PopUPData.Longexplan = $"Etherum Address copied to clipboard";
            await Navigation.PushAsync(new Pop_Up());
        }

        /// <summary>
        /// Copy LTC's donate address
        /// </summary>
        private async void LTC_Tapped(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync("LSExkyQisViq1vCKU6rbAV9TXr17HacQ4a");
            PopUPData.Title = "Done";
            PopUPData.Shortexplan = "Seccusfully";
            PopUPData.Longexplan = $"Litecoin Address copied to clipboard";
            await Navigation.PushAsync(new Pop_Up());
        }

        /// <summary>
        /// Copy DOGE's donate address
        /// </summary>
        private async void Doge_Tapped(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync("DGiVUnjw7RvhFYDjvkv1mU19kEGN4N8HUn");
            PopUPData.Title = "Done";
            PopUPData.Shortexplan = "Seccusfully";
            PopUPData.Longexplan = $"DogeCoin Address copied to clipboard";
            await Navigation.PushAsync(new Pop_Up());
        }

        /// <summary>
        /// Open developer's instagram page after tapping on his name, change it if you like but leave my name at the first page :) 
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