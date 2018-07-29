using System;
using System.Collections.Generic;
using Core.Helpers;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class TextCellView : ContentPage
    {
        public TextCellView()
        {
            InitializeComponent();

            lvlItem.ItemsSource = ItemHelper.Instance.GetItems();
        }
    }
}
