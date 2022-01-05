using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: ExportFont("UniNeueBold.otf", Alias = "UniNeueBold")]
[assembly: ExportFont("UniNeueBook.ttf", Alias = "UniNeueBook")]
[assembly: ExportFont("IRANSans.ttf", Alias = "IranSans")]
[assembly: ExportFont("BAUHS93.TTF", Alias = "BAUHS93")]
namespace ice_79.Droid
{
    [Activity(Label = "ice-79", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            if (string.IsNullOrWhiteSpace(Preferences.Get("Device_ID", null)))
            {
#pragma warning disable CS0612 // Type or member is obsolete
                Preferences.Set("Device_ID", LicenseData.DeviceID);
#pragma warning restore CS0612 // Type or member is obsolete
            }
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

}