using System.Threading.Tasks;
using Core.Contents;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class DetailLazyView : ContentPage
    {
        public DetailLazyView()
        {
            InitializeComponent();
            BindingContext = new ListViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Content is ActivityIndicator)
            {
                await Task.Delay(1000);
				Content = new DetailContent();
            }
        }
    }
}
