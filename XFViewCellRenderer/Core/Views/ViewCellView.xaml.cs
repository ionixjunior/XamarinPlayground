using System;
using System.Collections.Generic;
using Core.Helpers;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class ViewCellView : ContentPage
    {
        public ViewCellView()
        {
            InitializeComponent();

            lvlItem.ItemsSource = ItemHelper.Instance.GetItems();
        }
    }
}
