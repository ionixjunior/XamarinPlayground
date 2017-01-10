using Core.Controls;
using Core.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomContentPage), typeof(CustomContentPageRenderer))]
namespace Core.Droid.Renderers
{
	public class CustomContentPageRenderer : PageRenderer
	{
	}
}
