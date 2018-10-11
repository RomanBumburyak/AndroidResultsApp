using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidResultsApp
{
    [Activity(Label = "AndroidResultsApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TextView PhoneNumberText = FindViewById<TextView>(Resource.Id.PhoneNumberText);
            TextView TranslatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);
            Button TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            string translatedNumber = string.Empty;

            TranslateButton.Click += (sender, e) =>
            {
                translatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    TranslatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    TranslatedPhoneWord.Text = translatedNumber;
                }
            };


        }
    }
}

