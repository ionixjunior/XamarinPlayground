using Core.Controls;
using Core.ViewModels;

namespace Core.Views
{
	public partial class HomeView : CustomContentPage
	{
		public HomeView()
		{
			InitializeComponent();
			BindingContext = new HomeViewModel();
		}
	}
}
