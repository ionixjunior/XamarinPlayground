using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class TabView : TabbedPage
    {
        public TabView()
        {
            InitializeComponent();
            BindingContext = new SampleViewModel();
        }
    }
}
