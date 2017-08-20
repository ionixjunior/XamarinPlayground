using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;
using Core.Droid.Impl;
using Core.Interfaces;

namespace Core.Droid
{
    [Activity(Label = "MeetupTestes", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var container = BuildDependencies();
            LoadApplication(new App(container));
        }

		private ContainerBuilder BuildDependencies()
		{
			var container = new ContainerBuilder();

			container.RegisterType<SQLiteImpl>().As<ISQLite>().SingleInstance();

			return container;
		}
    }
}
