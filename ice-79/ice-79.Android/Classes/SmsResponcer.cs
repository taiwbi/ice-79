using Plugin.Messaging;
using System;
using System.Threading.Tasks;
using Android.Content;
using Xamarin.Essentials;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using ice_79;
using Android.Runtime;

namespace ice_79.Droid
{
    [Preserve(AllMembers = true)]
    public static class SmsResponcer
    {
        /// <summary>
        /// After receiving the message, the text and address of the message are sent to this function to check it and respond to it.
        /// </summary>
        /// <param name="MessageBody">The text of the SMS</param>
        /// <param name="Address">The number wich sent the message</param>
        /// <param name="context">context</param>
        public static async void Respond(string MessageBody, string Address, Context context)
        {
            String[] MessageSpliter = MessageBody.Split(new string[] { "/$ " }, StringSplitOptions.None);
            if (MessageSpliter[0] == "ice-79")
            {
                var SendSms = CrossMessaging.Current.SmsMessenger;
                string PhoneNumber;
                if (Address == UserData.TrustNum1)
                {
                    PhoneNumber = UserData.TrustNum1;
                }
                else if (Address == UserData.TrustNum2)
                {
                    PhoneNumber = UserData.TrustNum2;
                }
                else if (Address == UserData.TrustNum3)
                {
                    PhoneNumber = UserData.TrustNum3;
                }
                else if (Address == UserData.TrustNum4)
                {
                    PhoneNumber = UserData.TrustNum4;
                }
                else if (Address == UserData.TrustNum5)
                {
                    PhoneNumber = UserData.TrustNum5;
                }
                else
                {
                    SendSms.SendSmsInBackground(Address, "To prevent fraud and hacking, Ice-79 checks the sender's number in several steps to make sure there's no different between trusted number and sender's number. Your number was confirmed in the first step, but unfortunately there was a problem in the second step, please try another trusted number or try this after a few moments.");
                    LastSentLocations.NewSend(Address, "Unavailable", "Request Recieved but not sent! Reason: Access Deined. number disn't exist in trusted numbers.");
                    return;
                }
                if (MessageSpliter[1] == "get location")
                {
                    SendSms.SendSmsInBackground(PhoneNumber, "it's ice-79, command recieved. Processing...");
                    var SyncLocationPublic = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromMinutes(10),
                    });
                    string LocationSmsPublc = $"It's ice-79. Phone's location:{Environment.NewLine}{SyncLocationPublic.Latitude}, {SyncLocationPublic.Longitude}";
                    CrossMessaging.Current.SmsMessenger.SendSmsInBackground(PhoneNumber, LocationSmsPublc);
                    LastSentLocations.NewSend(PhoneNumber, $"{SyncLocationPublic.Latitude}, {SyncLocationPublic.Longitude}", "Successfully sent.");
                }
                else
                {
                    SendSms.SendSmsInBackground(PhoneNumber, "command is not specified.");
                }
            }
        }
    }
}
