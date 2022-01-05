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
    public partial class ReportBug : ContentPage
    {
        public string DeviceDatas = "Device model: " + DeviceInfo.Model + "\nDevice manufacturer: " + DeviceInfo.Manufacturer + "\nPlatform: " + DeviceInfo.Platform + "\nOS: " + DeviceInfo.VersionString;
        string BugOrContact;
        public ReportBug(string _bugorcon)
        {
            InitializeComponent();
            DeviceInfoLabel.Text = "Your device information is as follows and will be sent to us along with your message:\n" + DeviceDatas;
            BugOrContact = _bugorcon;
            PgTitle.Text = _bugorcon;
        }

        private async void SendButt_Clicked(object sender, EventArgs e)
        {
            if (SubjectEntry.Text != null && DescriEntry.Text != null)
            {
                try
                {
                    var EmailMsg = new EmailMessage
                    {
                        Subject = $"New {BugOrContact}: {SubjectEntry.Text}",
                        Body = DescriEntry.Text + "\nDevice Info: \n" + DeviceDatas,
                        To = { "ice79@taiwbi.ir" }
                    };
                    await Email.ComposeAsync(EmailMsg);
                    await Navigation.PopAsync();
                }
                catch (FeatureNotSupportedException)
                {
                    PopUPData.Title = "Not Supported";
                    PopUPData.Shortexplan = "Phone does not support this option";
                    PopUPData.Longexplan = "Unfortunatly, Your phone doesn't support sending email so we can't send report directly from app.\nYou can send us report to: ice79@taiwbi.ir";
                    await Navigation.PushAsync(new Pop_Up());
                }
                catch (Exception)
                {
                    PopUPData.Title = "Error";
                    PopUPData.Shortexplan = "Something went wrong";
                    PopUPData.Longexplan = "I'm sorry! we couldn't send report but we don't know why. Try again later or you can send us report to: ice79@taiwbi.ir";
                    await Navigation.PushAsync(new Pop_Up());
                }
            }
            else
            {
                PopUPData.Title = "Empty";
                PopUPData.Shortexplan = "Fields can not be empty";
                PopUPData.Longexplan = "Fields can not be empty. Please fill theme and try again.";
                await Navigation.PushAsync(new Pop_Up());
            }
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