using System;
using System.Collections.Generic;
using Core.Helpers;
using Core.Models;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();

            lvlMenu.ItemsSource = MenuHomeHelper.Instance.GetMenus();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuHome = e.SelectedItem as MenuHome;
            var viewType = menuHome?.View;

            if (viewType == null)
                return;

            var page = Activator.CreateInstance(viewType) as Page;
            if (page == null)
                return;
            
            Navigation.PushAsync(page);
        }
    }
}
