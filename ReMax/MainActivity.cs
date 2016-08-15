using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ReMax
{
    [Activity(Label = "ReMax", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();

            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += (sender, e) =>
             {
                 var intent = new Intent(this, typeof(MainMenuActivity));
                 StartActivity(intent);
             };
        }
        
    }
}

