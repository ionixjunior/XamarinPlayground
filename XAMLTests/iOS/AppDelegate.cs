using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Syncfusion.SfSchedule.XForms.iOS;
using UIKit;

namespace Core.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfScheduleRenderer.Init();

            var xfApplication = new App();

#if DEBUG
            Xamarin.Forms.HotReloader.Current.Start(xfApplication, 4291);
#endif

            LoadApplication(xfApplication);

            //LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
            //  new UXDivers.Gorilla.Config("Good Gorilla")
            //    .RegisterAssemblyFromType<Syncfusion.SfSchedule.XForms.SfSchedule>()
            //));

            return base.FinishedLaunching(app, options);
        }
    }
}
