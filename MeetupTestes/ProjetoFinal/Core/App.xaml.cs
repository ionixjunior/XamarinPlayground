using Autofac;
using Core.Helpers;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core
{
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        public App()
        {
            InitializeComponent();
        }

        public App(ContainerBuilder container)
        {
			InitializeComponent();
            Container = BuildDependencies(container).Build();

			PrepareDatabase();
			NavigationHelper.Instance.StartNavigationPage<ClienteViewModel>("Meus clientes");
        }

		private ContainerBuilder BuildDependencies(ContainerBuilder container)
		{
            container.RegisterType<ClienteViewModel>();
            container.RegisterType<ClienteDetalheViewModel>();
            container.RegisterType<ClienteService>().SingleInstance();

			return container;
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
            ISQLite db = null;

            using (var scope = Container.BeginLifetimeScope())
                db = scope.Resolve<ISQLite>();
            
            if (db == null)
                return;

            db.GetConnection().CreateTable<ClienteModel>();
        }
    }
}
