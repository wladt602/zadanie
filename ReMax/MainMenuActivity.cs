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
        }        
    }
}