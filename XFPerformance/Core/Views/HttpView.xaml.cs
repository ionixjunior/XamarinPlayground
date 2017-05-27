using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class HttpView : ContentPage
    {
        public HttpView()
        {
            InitializeComponent();
            BindingContext = new HttpViewModel();
        }
    }
}
