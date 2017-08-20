﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ViewModels;
using Xamarin.Forms;
using Autofac;

namespace Core.Helpers
{
    public class NavigationHelper
    {
        private static NavigationHelper _instance;
        public static NavigationHelper Instance => _instance ?? (_instance = new NavigationHelper());

        private NavigationHelper() {}

        public void StartNavigationPage<TViewModel>(string title) where TViewModel : BaseViewModel
        {
            var page = ResolvePage<TViewModel>(title);
            if (page == null)
                return;

            Application.Current.MainPage = new NavigationPage(page);
        }

        public void StartMasterDetail<TViewModelMaster, TViewModelDetail>(string titleMaster, string titleDetail)
            where TViewModelMaster : BaseViewModel
            where TViewModelDetail : BaseViewModel
        {
            var master = ResolvePage<TViewModelMaster>(titleMaster);
            if (master == null)
                return;

            var detail = ResolvePage<TViewModelDetail>(titleDetail);
            if (detail == null)
                return;

            master.Title = titleMaster;

            Application.Current.MainPage = new MasterDetailPage()
            {
                Master = master,
                Detail = new NavigationPage(detail)
            };
        }

        public async Task NavigateAsync<TViewModel>(string title, Dictionary<string, string> parameters = null) where TViewModel : BaseViewModel
        {
            var page = ResolvePage<TViewModel>(title, parameters);
            await GetNavigation().PushAsync(page);
        }

        public async Task BackAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : BaseViewModel
        {
            await GetNavigation().PopAsync();

            var lastPage = GetNavigation().NavigationStack.LastOrDefault();
            if (lastPage == null)
                return;

            if (!lastPage.BindingContext.GetType().Equals(typeof(TViewModel)))
                return;

            action?.Invoke(lastPage.BindingContext as TViewModel);
        }

        private Page ResolvePage<TViewModel>(string title, Dictionary<string, string> parameters = null) where TViewModel : BaseViewModel
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

                TViewModel viewModel = null;

                using (var scope = App.Container.BeginLifetimeScope())
                    viewModel = scope.Resolve<TViewModel>();

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

        private INavigation GetNavigation()
        {
            var mainPage = Application.Current.MainPage;

            if (mainPage is MasterDetailPage)
                return ((MasterDetailPage)mainPage).Detail.Navigation;

            if (mainPage is TabbedPage)
                return mainPage.Navigation;
            
            return mainPage.Navigation;
        }
    }
}
