using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class OptionView : ContentPage
	{
		public OptionView()
		{
			InitializeComponent();
			BindingContext = new OptionViewModel();
		}
	}
}
