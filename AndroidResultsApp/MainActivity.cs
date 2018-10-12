using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;

namespace AndroidResultsApp
{
    [Activity(Label = "AndroidResultsApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TextView PhoneNumberText = FindViewById<TextView>(Resource.Id.PhoneNumberText);
            TextView TranslatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);
            Button TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button TranslationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);
            Button ButtonToSendEmail = FindViewById<Button>(Resource.Id.ButtonToSendEmail); 

            string translatedNumber = string.Empty;

            TranslateButton.Click += (sender, e) =>
            {
                translatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    TranslatedPhoneWord.Text = "";
                }
                else
                {
                    TranslatedPhoneWord.Text = translatedNumber;
                    phoneNumbers.Add(translatedNumber);
                    TranslationHistoryButton.Enabled = true;
                }
            };


            TranslationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);

            };

            ButtonToSendEmail.Click += delegate
            {
                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[]{
                    "romanbumburyak@gmail.com",
                    "rb@gmail.com"
                });

                email.PutExtra(Android.Content.Intent.ExtraCc, new string[]{
                    "romanbumburyak@yahoo.com"
                });

                email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Xam");
                email.PutExtra(Android.Content.Intent.ExtraText, "Hey there this is XAM");
                email.SetType("message/rfc822");
                StartActivity(email);
            };

                               

        }
    }
}

