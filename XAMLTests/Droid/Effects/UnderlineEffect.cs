using System;
using Android.Graphics;
using Android.Widget;
using Core.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName(Core.Effects.UnderlineEffect.EffectNamespace)]
[assembly: ExportEffect(typeof(UnderlineEffect), nameof(UnderlineEffect))]
namespace Core.Droid.Effects
{
    public class UnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            SetUnderline(true);
        }

        protected override void OnDetached()
        {
            SetUnderline(false);
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == Label.TextProperty.PropertyName || args.PropertyName == Label.FormattedTextProperty.PropertyName)
                SetUnderline(true);
        }

        private void SetUnderline(bool underlined)
        {
            try
            {
                var textView = (TextView)Control;

                if (underlined)
                    textView.PaintFlags |= PaintFlags.UnderlineText;
                else
                    textView.PaintFlags &= ~PaintFlags.UnderlineText;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
