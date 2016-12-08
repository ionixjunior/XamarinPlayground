using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class ContactDetailView : ContentPage
	{
		public ContactDetailView(string id)
		{
			InitializeComponent();
			BindingContext = new ContactDetailViewModel(id);
		}
	}
}
