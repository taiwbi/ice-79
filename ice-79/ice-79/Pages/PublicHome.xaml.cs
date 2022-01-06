using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace ice_79
{
    /// <summary>
    /// Homepage (Not the first page)
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicHome : ContentPage
    {
        public PublicHome()
        {
            InitializeComponent();
            LoadPage();
        }

        //
        // functions
        //
        public async void LoadPage()
        {
            try
            {
                TrustedNum1.Text = UserData.TrustNum1;
                TrustedNum2.Text = UserData.TrustNum2;
                TrustedNum3.Text = UserData.TrustNum3;
                TrustedNum4.Text = UserData.TrustNum4;
                TrustedNum5.Text = UserData.TrustNum5;
            }
            catch (Exception ex)
            {
                PopUPData.Title = "Error";
                PopUPData.Shortexplan = "An error happened in loading trusted numbers";
                PopUPData.Longexplan = $"Error Log: {ex}";
                await Navigation.PushAsync(new Pop_Up());
            }
        }
        //
        // Buttons
        //
        private async void SaveTrustedNum_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserData.TrustNum1 = TrustedNum1.Text;
                UserData.TrustNum2 = TrustedNum2.Text;
                UserData.TrustNum3 = TrustedNum3.Text;
                UserData.TrustNum4 = TrustedNum4.Text;
                UserData.TrustNum5 = TrustedNum5.Text;
                var LocPermiStatus = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
                var SmsPermiStatus = await Permissions.CheckStatusAsync<Permissions.Sms>();
                bool CheckAgain = false;
                if (LocPermiStatus != PermissionStatus.Granted)
                {
                    var LocPermiReq = await Permissions.RequestAsync<Permissions.LocationAlways>();
                    CheckAgain = true;
                }
                if (SmsPermiStatus != PermissionStatus.Granted)
                {
                    var SmsPermiReq = await Permissions.RequestAsync<Permissions.Sms>();
                    CheckAgain = true;
                }
                if (CheckAgain == true)
                {
                    LocPermiStatus = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
                    SmsPermiStatus = await Permissions.CheckStatusAsync<Permissions.Sms>();
                    if (LocPermiStatus != PermissionStatus.Granted || SmsPermiStatus != PermissionStatus.Granted)
                    {
                        PopUPData.Title = "Permission Error";
                        PopUPData.Shortexplan = "App doesn't have necessary permissions";
                        PopUPData.Longexplan = "We have your numbers stored, but we do not have the permissions needed to receive requests or give you the location if something goes wrong with your phone.\nTo give the app these permissions, go to Settings, Apps, Ice-79, Permissions and enable SMS and Location permissions.If you are using Android 12, you should change the location permission mode to \"always allow\".\nThis application is fully open source and we will never share your location with our servers or anyone else. We respect your privacy.";
                        await Navigation.PushAsync(new Pop_Up());
                        return;
                    }
                }
                PopUPData.Title = "Successful";
                PopUPData.Shortexplan = "Successful operation";
                PopUPData.Longexplan = "Your numbers saved seccesfully!";
                await Navigation.PushAsync(new Pop_Up());
                return;
            }
            catch (Exception)
            {
                PopUPData.Title = "Error";
                PopUPData.Shortexplan = "Something went wrong";
                PopUPData.Longexplan = "Something happens while we were tryign to save your numbers. We're sorry about this! you can send feedback for us: ice-79@taiwbi.ir.";
                await Navigation.PushAsync(new Pop_Up());
            }
        }

        private async void RemoveAllNums_Clicked(object sender, EventArgs e)
        {

            try
            {
                UserData.TrustNum1 = null;
                UserData.TrustNum2 = null;
                UserData.TrustNum3 = null;
                UserData.TrustNum4 = null;
                UserData.TrustNum5 = null;
                PopUPData.Title = "Successful";
                PopUPData.Shortexplan = "Successful operation";
                PopUPData.Longexplan = "Your numbers deleted seccesfully!";
                await Navigation.PushAsync(new Pop_Up());
            }
            catch (Exception ex)
            {
                PopUPData.Title = "Error";
                PopUPData.Shortexplan = "Something went wrong";
                PopUPData.Longexplan = $"Something happens while we were tryign to delete your numbers. We're sorry about this! you can send feedback for us: ice-79@taiwbi.ir.\nError Log: {ex}";
                await Navigation.PushAsync(new Pop_Up());
            }
        }

        private async void MsgGuide_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MsgGuide());
        }

        private async void Licenseinfo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LicenseInfo());
        }

        private async void Guideprivacyterms_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuidelinesPage());
        }

        private async void ReportBug_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportBug("Bug Report"));
        }

        private async void LastSentLocations_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LastLocSent());
        }

        private async void Contactus_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportBug("Contact Message"));
        }

        private async void FrequentlyAsked_Tapped(object sender, EventArgs e)
        {
            PopUPData.Title = "Wait for it";
            PopUPData.Shortexplan = "Update option";
            PopUPData.Longexplan = "This option will add in future updates, Please check our page for newer versions.";
            await Navigation.PushAsync(new Pop_Up());
        }
    }
}