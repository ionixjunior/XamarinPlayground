using System;
using Xamarin.Forms;
using Core.Interfaces;

namespace Core.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        async void YesOrNoClicked(object sender, EventArgs e)
        {
            await DisplayAlert("What is your answer?", "Decide now...", "Yes", "No");
        }

		async void ShowImageClicked(object sender, EventArgs e)
		{
            await DependencyService.Get<IFile>().OpenFromResource("monkey.png");
		}
    }
}
