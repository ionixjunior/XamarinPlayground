using Android.Content;
using Android.Graphics;
using Core.Controls;
using Core.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace Core.Droid.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            Control.PaintFlags = PaintFlags.UnderlineText;
            Control.SetTextColor(Android.Graphics.Color.Black);
        }
    }
}
