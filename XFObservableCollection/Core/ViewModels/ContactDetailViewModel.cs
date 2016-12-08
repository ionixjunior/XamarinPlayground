using System.Threading.Tasks;
using System.Windows.Input;
using Core.Fake;
using Core.Helpers;
using Core.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace Core.ViewModels
{
	[ImplementPropertyChanged]
	public class ContactDetailViewModel
	{
		public ICommand SaveCommand =>
			new Command(async () => await Save());

		private string _id;
		public string Name { get; set; }
		public string Email { get; set; }
		public bool IsFavorite { get; set; }

		public ContactDetailViewModel(string id)
		{
			_id = id;
			ContactModel model = ContactFake.GetById(id);

			Name = model.Name;
			Email = model.Email;
			IsFavorite = model.IsFavorite;
		}

		private async Task Save()
		{
			ContactModel model = ContactFake.Update(_id, Name, Email, IsFavorite);
			MessagingCenter.Send(model, "UpdateList");
			await NavigationHelper.GetInstance().GoBack();
		}
	}
}
