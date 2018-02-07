using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class MonkeyView : ContentPage
    {
        public MonkeyView()
        {
            InitializeComponent();
            BindingContext = new MonkeyViewModel();
        }
    }
}
