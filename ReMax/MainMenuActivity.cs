using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ReMax.Classes;

namespace ReMax
{
    [Activity(Label = "Hlavné menu", Theme = "@style/MyTheme", Icon = "@drawable/ic_home")]
    public class MainMenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.MainMenu);

            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(Resources.GetString(Resource.String.tabTransport_txt));
            tab.TabSelected += (sender, args) =>
             {
                 SetContentView(Resource.Layout.Menu);
             };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText(Resources.GetString(Resource.String.tabAdministration_txt));
            tab.TabSelected += (sender, args) =>
            {
                SetContentView(Resource.Layout.Administration);
            };
            ActionBar.AddTab(tab);



            var lblLogedUser = FindViewById<TextView>(Resource.Id.lblLogedUser);
            lblLogedUser.Text = User.UserName;

            var btnLogOut = FindViewById<Button>(Resource.Id.btnLogOut);
            btnLogOut.Click += LogOutClick;
            
        }

        void LogOutClick(object sender, EventArgs arg)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Odhlási");
            alert.SetMessage("Skutoène sa chcete odhlási?");
            alert.SetPositiveButton("ANO", (senderAlert, args) =>
            {
                User u = new User();
                u.Logout();
                Finish();
            });
            alert.SetNegativeButton("NIE", (senderAlert, args) =>
            {
                alert.Dispose();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public override void OnBackPressed()
        {
            LogOutClick(null,null);
        }
    }
}