﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace eShiatsu_App
{
    [Activity(Label = "eShiatsu", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar", Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        WebView web_view;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            web_view = FindViewById<WebView>(Resource.Id.LocalWebView);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.LoadUrl("https://www.eshiatsu.com/");
            web_view.SetWebViewClient(new HelloWebViewClient());
        }
        public class HelloWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }
        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && web_view.CanGoBack())
            {
                web_view.GoBack();
                return true;
            }

            return base.OnKeyDown(keyCode, e);
        }
    }
}

