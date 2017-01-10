using Core.Controls;
using Core.iOS.Renderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomContentPage), typeof(CustomContentPageRenderer))]
namespace Core.iOS.Renderers
{
	public class CustomContentPageRenderer : PageRenderer
	{
		public override void WillMoveToParentViewController(UIViewController parent)
		{
			base.WillMoveToParentViewController(parent);

			if (Element == null)
				return;

			var page = Element as CustomContentPage;

			UIButton buttonTitle = new UIButton(UIButtonType.Custom);
			buttonTitle.SetTitle(page.Title, UIControlState.Normal);
			buttonTitle.SetImage(new UIImage(page.Icon), UIControlState.Normal);
			buttonTitle.SetTitleColor(UIColor.Black, UIControlState.Normal);
			buttonTitle.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
			buttonTitle.TitleLabel.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
			buttonTitle.ImageView.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
			buttonTitle.ImageEdgeInsets = new UIEdgeInsets(0, -20, 0, 0);
			buttonTitle.SetTitleColor(UIColor.Gray, UIControlState.Highlighted);
			buttonTitle.TitleLabel.Font = UIFont.BoldSystemFontOfSize(14);
			buttonTitle.SizeToFit();
			buttonTitle.TouchUpInside += (sender, e) =>
			{
				if (page.Command == null)
					return;
				
				if (page.Command.CanExecute(null))
					page.Command.Execute(null);
			};

			parent.NavigationItem.TitleView = buttonTitle;
		}
	}
}
