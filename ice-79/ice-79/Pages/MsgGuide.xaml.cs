using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ice_79
{
    /// <summary>
    /// Send command messages to a device sirectly from the application
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MsgGuide : ContentPage
    {
        public MsgGuide()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Opens developer's instagram page after tapping on his name, change it if you like but leave my name at the first page :) 
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
        /// <summary>
        /// Analyze the request and sends command text message to the target phone number
        /// </summary>
        /// <param name="sender">system param</param>
        /// <param name="e">system param</param>
        private async void SendMsgButt_Clicked(object sender, EventArgs e)
        {
            string Number = PhoneNumber.Text;
            int Selected = SelectedAction.SelectedIndex;
            if (Selected == 0)
            {
                try
                {
                    var permistatus = await Permissions.CheckStatusAsync<Permissions.Sms>();
                    if (permistatus != PermissionStatus.Granted)
                    {
                        var permirequ = await Permissions.RequestAsync<Permissions.Sms>();
                    }
                    var message = new SmsMessage("ice-79/$ get location", Number);
                    await Sms.ComposeAsync(message);
                }
                catch
                {
                    try
                    {
                        var message = new SmsMessage("ice-79/$ get location", new[] { Number });
                        await Sms.ComposeAsync(message);
                    }
                    catch (FeatureNotEnabledException)
                    {
                        PopUPData.Title = "Not supported";
                        PopUPData.Shortexplan = "Sms is not supported on this device";
                        PopUPData.Longexplan = $"We can't send Sms with your device. If you still wanna to find its location send 'ice-79/$ get location' to '{Number}'";
                        await Navigation.PushAsync(new Pop_Up());
                    }
                    catch
                    {
                        PopUPData.Title = "Error";
                        PopUPData.Shortexplan = "Something went wrong";
                        PopUPData.Longexplan = $"Something happened and I can't tell what it was. If you still wanna to find its location send 'ice-79/$ get location' to '{Number}'";
                        await Navigation.PushAsync(new Pop_Up());
                    }
                }
            }
            else
            {
                PopUPData.Title = "Future feature";
                PopUPData.Shortexplan = "This feature is not ready yet";
                PopUPData.Longexplan = "We're allways trying to make this app better and add features to this amazing app. ice-79 isn't completed yet.";
                await Navigation.PushAsync(new Pop_Up());
            }
        }
    }
}