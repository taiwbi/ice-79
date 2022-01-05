using System;
using Xamarin.Essentials;
/// <summary>
/// This page save and file date from global variables or andrid <c>Preferences</c>
/// I think everything is clear, I don't write more ducumination for this file :()
/// </summary>
namespace ice_79
{
    class LicenseData
    {
        public static string DeviceID
        {
            get
            {
                return Preferences.Get("Device_ID", null);
            }
        }
    }
    class PopUPData
    {
        public static string Title { get; set; }
        public static string Shortexplan { get; set; }
        public static string Longexplan { get; set; }
    }
    public class UserData
    {
        public static string TrustNum1
        {
            get => Preferences.Get("TrustedNumber1", null);
            set => Preferences.Set("TrustedNumber1", value);
        }
        public static string TrustNum2
        {
            get => Preferences.Get("TrustedNumber2", null);
            set => Preferences.Set("TrustedNumber2", value);
        }
        public static string TrustNum3
        {
            get => Preferences.Get("TrustedNumber3", null);
            set => Preferences.Set("TrustedNumber3", value);
        }
        public static string TrustNum4
        {
            get => Preferences.Get("TrustedNumber4", null);
            set => Preferences.Set("TrustedNumber4", value);
        }
        public static string TrustNum5
        {
            get => Preferences.Get("TrustedNumber5", null);
            set => Preferences.Set("TrustedNumber5", value);
        }

        public static string LicenseKey
        {
            set => SecureStorage.SetAsync("License_code", value);
            get => SecureStorage.GetAsync("License_code").ToString();
        }
    }
    public class SpecialUsersData
    {
        public static string UserNumber
        {
            set => Preferences.Set("UserNumberSotre", value);
            get => Preferences.Get("UserNumberSotre", null);
        }
        public static string UserPass
        {
            set => Preferences.Set("UserPassStore", value);
            get => Preferences.Get("UserPassStore", null);
        }
    }
    public class LastSentLocations
    {
        public static void NewSend(string _person, string _location, string _status)
        {
            try
            {
                LastSentLocations.Time += "-&-" + DateTime.Now.ToString();
                LastSentLocations.Person += $"-&-{_person}";
                LastSentLocations.Location += $"-&-{_location}";
                LastSentLocations.Status += $"-&-{_status}";
                LastSentLocations.num++;
            }
            catch
            {

            }
        }
        public static string GetTime(int _num)
        {
            string FullString = LastSentLocations.Time;
            String[] SplitedString = FullString.Split(new string[] { "-&-" }, StringSplitOptions.None);
            return SplitedString[_num];
        }
        public static string GetPerson(int _num)
        {
            string FullString = LastSentLocations.Person;
            String[] SplitedString = FullString.Split(new string[] { "-&-" }, StringSplitOptions.None);
            return SplitedString[_num];
        }
        public static string GetLocation(int _num)
        {
            string FullString = LastSentLocations.Location;
            String[] SplitedString = FullString.Split(new string[] { "-&-" }, StringSplitOptions.None);
            return SplitedString[_num];
        }
        public static string GetStatus(int _num)
        {
            string FullString = LastSentLocations.Status;
            String[] SplitedString = FullString.Split(new string[] { "-&-" }, StringSplitOptions.None);
            return SplitedString[_num];
        }
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        public static int num
        {
            get => Preferences.Get("SentLocationsNum", 0);
            set => Preferences.Set("SentLocationsNum", value);
        }
        private static string Time
        {
            get => Preferences.Get("SentLocationsTime", "Unkown");
            set => Preferences.Set("SentLocationsTime", value);
        }
        private static string Person
        {
            get => Preferences.Get("SentLocationsPerson", "Unkown");
            set => Preferences.Set("SentLocationsPerson", value);
        }
        private static string Location
        {
            get => Preferences.Get("SentLocationsLocatoin", "Unkown");
            set => Preferences.Set("SentLocationsLocatoin", value);
        }
        private static string Status
        {
            get => Preferences.Get("SentLocationsStatus", "Unkown");
            set => Preferences.Set("SentLocationsStatus", value);
        }
    }
}