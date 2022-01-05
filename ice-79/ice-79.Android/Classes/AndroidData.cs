using Android.OS;
using Android.Runtime;
using System;
using static Android.Provider.Settings;

namespace ice_79.Droid
{
    [Preserve(AllMembers = true)]
    public class LicenseData
    {
        /// <summary>
        /// Find Android Device ID
        /// </summary>
        [Obsolete]
        public static string DeviceID
        {
            get
            {
                string id = Build.Serial;
                if (!string.IsNullOrWhiteSpace(id) && id != Build.Unknown && id != "0")
                {
                    return id;
                }
                else
                {
                    try
                    {
                        var context = Android.App.Application.Context;
                        id = Secure.GetString(context.ContentResolver, Secure.AndroidId);
                        return id;
                    }
                    catch (Exception)
                    {
                        return ("Unable to get the device ID.");
                    }
                }
            }
        }
        /* Use this to get device ID in IOS:
         * public string Id => UIDevice.CurrentDevice.IdentifierForVendor.AsString();
         * I add returned the DeviceID to prefrences and get the prefrence value at PCL project
         */
    }
}