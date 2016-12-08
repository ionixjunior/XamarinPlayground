using System.Collections.ObjectModel;
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
	public class ContactViewModel
	{
		public ICommand GotoContactDetailCommand => 
			new Command<string>(async (id) => await GotoContactDetail(id));

		private ContactModel _selectedItem;
		public ContactModel SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;
				if (_selectedItem == null)
					return;

				GotoContactDetailCommand.Execute(_selectedItem.Id);
				SelectedItem = null;
			}
		}

		public ObservableCollection<ContactModel> Data { get; set; }

		public ContactViewModel()
		{
			Data = new ObservableCollection<ContactModel>(ContactFake.GetAll());

			MessagingCenter.Subscribe(this, "UpdateList", (ContactModel model) =>
			{
				System.Diagnostics.Debug.WriteLine("Updating list...");
				int index = Data.IndexOf(model);
				Data[index] = model;
			});
		}

		private async Task GotoContactDetail(string id)
		{
			await NavigationHelper.GetInstance().GotoContactDetail(id);
		}
	}
}
