using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Helpers;
using Core.Interfaces;
using Core.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace Core.ViewModels
{
	[ImplementPropertyChanged]
	public class HomeViewModel : BaseViewModel
	{
		public ObservableCollection<ContactModel> Contacts { get; set; }

		public ICommand GotoAddCommand 
			=> new Command(async () => await GotoAdd());

		public HomeViewModel()
		{
			Contacts = new ObservableCollection<ContactModel>();
		}

		public async Task LoadData()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;

				var data = await DependencyService
					.Get<IServerService>()
					.Get();

				Contacts.Clear();

				foreach (var repo in data)
					Contacts.Add(repo);
			}
			catch (Exception e)
			{
				await Application.Current.MainPage.DisplayAlert(
					"An error occurred",
					e.Message,
					"Ok"
				);
			}
			finally
			{
				IsBusy = false;
			}
		}

		private async Task GotoAdd()
		{
			await NavigationHelper.Instance.GotoDetail();
		}
	}
}
