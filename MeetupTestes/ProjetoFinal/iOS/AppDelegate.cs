using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Autofac;
using Core.iOS.Impl;
using Core.Interfaces;

namespace Core.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

#if DEBUG
            Xamarin.Calabash.Start();
#endif

            var container = BuildDependencies();
            LoadApplication(new App(container));

            return base.FinishedLaunching(app, options);
        }

        private ContainerBuilder BuildDependencies()
        {
            var container = new ContainerBuilder();

            container.RegisterType<SQLiteImpl>().As<ISQLite>().SingleInstance();

            return container;
        }
    }
}
