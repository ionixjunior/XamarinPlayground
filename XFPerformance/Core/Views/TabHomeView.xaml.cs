using System;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class TabHomeView : ContentPage
    {
        public TabHomeView()
        {
            InitializeComponent();
        }

        async void OnClickTraditional(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("## CLICADO ##");
            await Navigation.PushAsync(new TabView());
        }

		async void OnClickCustomized(object sender, EventArgs e)
		{
            System.Diagnostics.Debug.WriteLine("## CLICADO ##");
			await Navigation.PushAsync(new TabLazyView());
		}
    }
}
