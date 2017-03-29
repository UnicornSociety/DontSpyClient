﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace ModernEncryption.Droid
{
    [Activity(Label = "ModernEncryption.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            new ModernEncryption.App().Start();

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}
