using System;
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
	public class DetailViewModel : BaseViewModel
	{
		public ContactModel Contact { get; set; }

		public ICommand SaveCommand 
			=> new Command(async () => await Save());

		public ICommand DeleteCommand
			=> new Command(async () => await Delete());

		public DetailViewModel(ContactModel contactModel)
		{
			Contact = contactModel;
		}

		private async Task Save()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;

				if (string.IsNullOrEmpty(Contact.Id))
				{
					await DependencyService
						.Get<IServerService>()
						.Insert(Contact);
				}
				else
				{
					await DependencyService
						.Get<IServerService>()
						.Update(Contact.Id, Contact);
				}
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

			await NavigationHelper.Instance.GoBack();
		}

		private async Task Delete()
		{
			if (IsBusy)
				return;

			if (string.IsNullOrEmpty(Contact.Id))
				return;

			try
			{
				IsBusy = true;

				await DependencyService
					.Get<IServerService>()
					.Delete(Contact.Id);
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

			await NavigationHelper.Instance.GoBack();
		}
	}
}
