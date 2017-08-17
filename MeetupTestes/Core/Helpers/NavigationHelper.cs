using System;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Helpers
{
    public class NavigationHelper
    {
        private static NavigationHelper _instance;
        public static NavigationHelper Instance => _instance ?? (_instance = new NavigationHelper());

        private NavigationHelper() {}

        public void StartMainPage<TViewModel>() where TViewModel : BaseViewModel, new()
        {
            var page = ResolvePage<TViewModel>();
            if (page == null)
                return;

            Application.Current.MainPage = new NavigationPage(page);
        }

        public Page ResolvePage<TViewModel>() where TViewModel : BaseViewModel, new()
        {
            Page page = null;

            try
            {
				var viewModelType = typeof(TViewModel);
				var viewModelTypeName = viewModelType.Name;
				var viewModelSufixLength = "ViewModel".Length;
				var viewTypeName = $"Core.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelSufixLength)}View";
				var viewType = Type.GetType(viewTypeName);

				if (viewType == null)
					return null;

				page = Activator.CreateInstance(viewType) as Page;
				if (page == null)
					return null;

				var viewModel = new TViewModel();
				if (viewModel == null)
					return null;

				viewModel.Init();
				page.BindingContext = viewModel;
				page.Appearing += (sender, e) => { viewModel.OnAppearing(); };
				page.Disappearing += (sender, e) => { viewModel.OnDisappearing(); };
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return page;
        }
    }
}
