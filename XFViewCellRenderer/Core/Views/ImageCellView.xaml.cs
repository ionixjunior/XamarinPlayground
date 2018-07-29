using System;
using System.Collections.Generic;
using Core.Helpers;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class ImageCellView : ContentPage
    {
        public ImageCellView()
        {
            InitializeComponent();

            lvlItem.ItemsSource = ItemHelper.Instance.GetItems();
        }
    }
}
