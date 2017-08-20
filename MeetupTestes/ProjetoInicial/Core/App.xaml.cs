using Core.Helpers;
using Core.Interfaces;
using Core.Models;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            PrepareDatabase();
            NavigationHelper.Instance.StartNavigationPage<ClienteViewModel>("Meus clientes");
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

        private void PrepareDatabase()
        {
            var db = DependencyService.Get<ISQLite>();
            if (db == null)
                return;

            db.GetConnection().CreateTable<ClienteModel>();
        }
    }
}
