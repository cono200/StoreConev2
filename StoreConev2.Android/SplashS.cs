using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreConev2.Droid
{
    [Activity(Label = "StoreConev2", Icon = "@mipmap/icon", Theme = "@style/nuevoTema", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize)]
    //    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity

    public class Splashscreen1 : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //para suscribirnos a MainActivity
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}