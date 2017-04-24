using Core.Interfaces;
using Core.Services;
using Core.Views;
using Xamarin.Forms;

namespace Core
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//DependencyService.Register<IServerService, HttpClientService>();
			DependencyService.Register<IServerService, RefitService>();

			MainPage = new NavigationPage(
				new HomeView()
			);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
