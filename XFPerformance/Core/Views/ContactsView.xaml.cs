using System;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class ContactsView : ContentPage
    {
        public ContactsView()
        {
            InitializeComponent();
            BindingContext = new ListViewModel();
        }

        public async void OnItemSelected(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ContactsView());
        }
    }
}
