using Core.Controls;
using Core.iOS.Renderers;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace Core.iOS.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            if (e.NewElement == null)
                return;

            Control.AttributedText = new NSAttributedString(
                e.NewElement.Text,
                underlineStyle: NSUnderlineStyle.Single
            );
        }
    }
}
