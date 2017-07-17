using System.Threading.Tasks;
using Core.Contents;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class Sample2View : ContentPage
    {
        public Sample2View()
        {
            InitializeComponent();
            BindingContext = new SampleViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(500);
            Content = new SampleContent();
        }
    }
}
