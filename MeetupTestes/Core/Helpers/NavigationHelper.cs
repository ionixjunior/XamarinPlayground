using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Helpers
{
    public class NavigationHelper
    {
        private static NavigationHelper _instance;
        public static NavigationHelper Instance => _instance ?? (_instance = new NavigationHelper());

        private NavigationHelper() {}

        public void StartMainPage<TViewModel>(string title) where TViewModel : BaseViewModel, new()
        {
            var page = ResolvePage<TViewModel>(title);
            if (page == null)
                return;

            Application.Current.MainPage = new NavigationPage(page);
        }

        public async Task NavigateAsync<TViewModel>(string title, Dictionary<string, string> parameters = null) where TViewModel : BaseViewModel, new()
        {
            var page = ResolvePage<TViewModel>(title, parameters);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task BackAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PopAsync();

            var lastPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (lastPage == null)
                return;

            if (!lastPage.BindingContext.GetType().Equals(typeof(TViewModel)))
                return;

            action?.Invoke(lastPage.BindingContext as TViewModel);
        }

        private Page ResolvePage<TViewModel>(string title, Dictionary<string, string> parameters = null) where TViewModel : BaseViewModel, new()
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

                if (parameters == null)
                {
                    viewModel.Init();
                }
                else
                {
                    viewModel.Init(parameters);
                }

                viewModel.Title = title;
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
