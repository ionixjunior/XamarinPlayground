using Xamarin.Forms;

namespace Core.Effects
{
    public class UnderlineEffect : RoutingEffect
    {
        public const string EffectNamespace = "Core";

        public UnderlineEffect() : base($"{EffectNamespace}.{nameof(UnderlineEffect)}")
        {
        }
    }
}
