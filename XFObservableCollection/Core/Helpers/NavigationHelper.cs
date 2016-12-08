using Xamarin.Forms;
using System.Threading.Tasks;
using Core.Views;

namespace Core.Helpers
{
	public class NavigationHelper
	{
		private static NavigationHelper _instance;
		public static NavigationHelper GetInstance()
		{
			return _instance ?? (_instance = new NavigationHelper());
		}

		private NavigationHelper() { }

		public async Task GotoContactDetail(string id)
		{
			await Application.Current.MainPage.Navigation.PushAsync(new ContactDetailView(id));
		}

		public async Task GoBack()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}
	}
}
