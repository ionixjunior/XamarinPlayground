using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class DetailView : ContentPage
    {
        public DetailView()
        {
            InitializeComponent();
            BindingContext = new ListViewModel();
        }
    }
}
