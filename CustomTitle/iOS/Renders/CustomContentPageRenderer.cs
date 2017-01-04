using Core;
using Core.iOS.Renders;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomContentPage), typeof(CustomContentPageRenderer))]
namespace Core.iOS.Renders
{
	public class CustomContentPageRenderer : PageRenderer
	{
		public override void WillMoveToParentViewController(UIKit.UIViewController parent)
		{
			base.WillMoveToParentViewController(parent);

			if (Element == null)
				return;

			//var page = Element as ContentPage;

			UIButton buttonTitle = new UIButton(UIButtonType.Custom);
			buttonTitle.SetImage(new UIImage("down.png"), UIControlState.Normal);
			buttonTitle.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
			buttonTitle.TitleLabel.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
			buttonTitle.ImageView.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
			buttonTitle.SetTitle("Home", UIControlState.Normal);
			buttonTitle.SetTitleColor(UIColor.Black, UIControlState.Normal);
			buttonTitle.SizeToFit();

			parent.NavigationItem.TitleView = buttonTitle;		
		}
	}
}
