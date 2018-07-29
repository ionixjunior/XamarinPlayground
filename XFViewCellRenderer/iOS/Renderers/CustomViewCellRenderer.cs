using Core.Controls;
using Core.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace Core.iOS.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
            tv.SeparatorInset = new UIEdgeInsets(0, 66, 0, 0);

            return base.GetCell(item, reusableCell, tv);
		}
	}
}
