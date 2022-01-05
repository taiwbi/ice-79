using Android.App;
using Android.Content;
using Android.Widget;
using Plugin.Messaging;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using ice_79;
using System.IO;
using Android.Runtime;

namespace ice_79.Droid
{
    [Preserve(AllMembers = true)]
    [BroadcastReceiver]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class MyBroadcastReceiver : BroadcastReceiver
    {
        public static readonly string IntentAction = "android.provider.Telephony.SMS_RECEIVED";
        protected string Message, Address = "";
        /// <summary>
        /// Listen for text messages. Call this function only when you need to simulate receiving messages.
        /// </summary>
        public override void OnReceive(Context context, Intent intent)
        {

            if (intent.HasExtra("pdus"))
            {
                var smsArray = (Java.Lang.Object[])intent.Extras.Get("pdus");
                foreach (var item in smsArray)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    var sms = Android.Telephony.SmsMessage.CreateFromPdu((byte[])item);
#pragma warning restore CS0618 // Type or member is obsolete
                    Address = sms.OriginatingAddress;
                    Message = sms.MessageBody;
                    try
                    {

                        if (Address == UserData.TrustNum1 || Address == UserData.TrustNum2 || Address == UserData.TrustNum3 || Address == UserData.TrustNum4 || Address == UserData.TrustNum5)
                        {
                            Toast.MakeText(context, $"Sms Recieved from {Address}, Status: Relevent", ToastLength.Long).Show();
                            Task.Delay(3000).Wait();
                            SmsResponcer.Respond(Message, Address, context);
                            return;
                        }
                    }
                    catch
                    {
                        Toast.MakeText(context, $"Couldn't process message. try clear app cache and try again.", ToastLength.Long).Show();
                    }
                }
            }
        }
    }
}