using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ReMax.Classes;
using Android.Views.InputMethods;

namespace ReMax
{
    [Activity(Label = "ReMax", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();

            var inpUser = FindViewById<EditText>(Resource.Id.inpUserName);
            var inpPass = FindViewById<EditText>(Resource.Id.inpPassword);

            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            //Akcia na kliknutie na buton prihlasit
            btnLogin.Click += (sender, e) =>
            {
                string user = inpUser.Text.ToString();
                string pass = inpPass.Text.ToString();

                User u = new User();
                if (u.CheckUser(user, pass))
                {
                    inpUser.Text = "";
                    inpPass.Text = "";
                    var intent = new Intent(this, typeof(MainMenuActivity));
                    //intent.PutExtra("UserName", user);
                    StartActivity(intent);
                }
                else
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Chyba");
                    alert.SetMessage("Nesprávne meno alebo heslo.");
                    alert.SetNeutralButton("OK", (senderAlert, args)=>
                    {
                        alert.Dispose();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            };

            // Enter v poli Login posle do hesla
            inpUser.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    inpPass.RequestFocus();
                    InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                    imm.ShowSoftInput(inpPass, InputMethodManager.ShowImplicit);
                    e.Handled = true;
                }
            };

            //Enter v okne heslo odpali login button
            inpPass.KeyPress += (object sender, View.KeyEventArgs e) =>
             {
                 e.Handled = false;
                 if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                 {
                     btnLogin.PerformClick();
                     e.Handled = true;
                 }
             };
        }

    }
}

