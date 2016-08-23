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

namespace ReMax.Classes
{
    class User
    {
        public static string UserName;
        

        public bool CheckUser(string user, string pass)
        {
            if (user == "admin")
            {
                if (pass == "admin")
                {
                    UserName = user;
                    return true;
                }
            }
            return false;
        }

        public void Logout()
        {
            UserName = null;
        }
    }
}