using Core.Helpers;
using Core.Models;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class HomeView : ContentPage
	{
		private HomeViewModel _viewModel;

		public HomeView()
		{
			InitializeComponent();
			_viewModel = new HomeViewModel();
			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (_viewModel != null)
				await _viewModel.LoadData();
		}

		private async void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			var contactModel = e.Item as ContactModel;
			await NavigationHelper.Instance.GotoDetail(contactModel);
		}
	}
}
