using Core.Views;
using Xamarin.Forms;

namespace Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			MainPage = new NavigationPage(
			    new TabHomeView()
			);

			//MainPage = new NavigationPage(
   //             new ModalHomeView()
			//);

			//MainPage = new MasterDetailView();

			//MainPage = new NavigationPage(
			//	new HttpView()
			//);

			//MainPage = new NavigationPage(
   //             new ContactsView()
			//);
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
