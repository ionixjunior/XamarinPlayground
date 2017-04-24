using System;
using System.Threading.Tasks;
using Core.Models;
using Core.ViewModels;
using Core.Views;
using Xamarin.Forms;

namespace Core.Helpers
{
	public class NavigationHelper
	{
		private static NavigationHelper _instance;
		public static NavigationHelper Instance 
			=> _instance ?? (_instance = new NavigationHelper());

		private NavigationHelper() {}

		private INavigation GetNavigation()
		{
			return Application.Current.MainPage.Navigation;
		}

		public async Task GotoDetail()
		{
			await GotoDetail(new ContactModel());
		}

		public async Task GotoDetail(ContactModel contactModel)
		{
			var detailView = new DetailView();
			detailView.BindingContext = new DetailViewModel(contactModel);

			await GetNavigation().PushAsync(detailView);
		}

		public async Task GoBack()
		{
			await GetNavigation().PopAsync();
		}
	}
}
