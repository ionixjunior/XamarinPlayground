using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Core.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());
			BuildStyles();

            return base.FinishedLaunching(app, options);
        }

        private void BuildStyles()
        {
            var xfResources = Xamarin.Forms.Application.Current.Resources;
            if (xfResources == null)
                return;

            var mainColor = "MainColor";
            var mainBarTextColor = "MainBarTextColor";

            if (!xfResources.ContainsKey(mainColor) || !xfResources.ContainsKey(mainBarTextColor))
                return;

            var xfMainColor = (Xamarin.Forms.Color)xfResources[mainColor];
            var xfMainBarTextColor = (Xamarin.Forms.Color)xfResources[mainBarTextColor];

            var uiMainColor = UIColor.FromRGB(
				(nfloat)xfMainColor.R,
				(nfloat)xfMainColor.G,
				(nfloat)xfMainColor.B
			);

			var uiMainBarTextColor = UIColor.FromRGB(
				(nfloat)xfMainBarTextColor.R,
				(nfloat)xfMainBarTextColor.G,
				(nfloat)xfMainBarTextColor.B
			);

            UINavigationBar.Appearance.BarTintColor = uiMainColor;
            UINavigationBar.Appearance.TintColor = uiMainBarTextColor;
            UINavigationBar.Appearance.SetTitleTextAttributes(
                new UITextAttributes() { TextColor = uiMainBarTextColor }
            );
            UIView.Appearance.TintColor = uiMainColor;
        }
    }
}
