using System;
using System.Collections.Generic;
using Core.Helpers;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class CustomViewCellView : ContentPage
    {
        public CustomViewCellView()
        {
            InitializeComponent();

            lvlItem.ItemsSource = ItemHelper.Instance.GetItems();
        }
    }
}
