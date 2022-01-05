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
    public partial class LastLocSent : ContentPage
    {
        public LastLocSent()
        {
            InitializeComponent();
            LoadLog();
        }
        /// <summary>
        /// Loads the data from <c>LastSentLocations</c> class
        /// </summary>
        void LoadLog()
        {
            if (LastSentLocations.num == 0)
            {
                MainText.Text = "No Requests recieved yet!";
            }
            else
            {
                for (int i = LastSentLocations.num; i > 0; i--)
                {
                    int n = i;
                    MainText.Text += $"Request from: {LastSentLocations.GetPerson(n)}\n" +
                        $"Time: {LastSentLocations.GetTime(n)}\n" +
                        $"Location: {LastSentLocations.GetLocation(n)}\n" +
                        $"Status: {LastSentLocations.GetStatus(n)}\n" +
                        $"____________________\n";
                }
            }
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