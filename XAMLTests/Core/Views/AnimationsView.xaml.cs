using System.Threading.Tasks;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class AnimationsView : ContentPage
    {
        private Task _init;

        public AnimationsView()
        {
            InitializeComponent();
            _init = Init();
        }

        private async Task Init()
        {
            await imgIcon.RotateTo(360, 1000);
            await imgIcon.RotateTo(0, 0);
            await Init();
        }
    }
}
