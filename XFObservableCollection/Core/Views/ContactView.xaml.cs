using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class ContactView : ContentPage
	{
		public ContactView()
		{
			InitializeComponent();
			BindingContext = new ContactViewModel();
		}
	}
}
