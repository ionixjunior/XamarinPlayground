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

        protected override void OnCurrentPageChanged()
        {
            System.Diagnostics.Debug.WriteLine("## ABA TROCADA ##");
            base.OnCurrentPageChanged();
        }
    }
}
