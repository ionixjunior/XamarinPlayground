using System;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class ModalHomeView : ContentPage
    {
        public ModalHomeView()
        {
            InitializeComponent();
        }

		async void OnClickTraditional(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("## CLICADO ##");
            await Navigation.PushModalAsync(new NavigationPage(new SampleView()));
		}

		async void OnClickCustomized(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("## CLICADO ##");
			await Navigation.PushModalAsync(new NavigationPage(new SampleView()));
		}
    }
}
