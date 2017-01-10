using System.Threading.Tasks;
using System.Windows.Input;
using Core.Views;
using PropertyChanged;
using Xamarin.Forms;

namespace Core.ViewModels
{
	[ImplementPropertyChanged]
	public class HomeViewModel
	{
		public ICommand OpenOptionCommand 
			=> new Command(async () => await OpenOption());

		private async Task OpenOption()
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(
				new NavigationPage(new OptionView())
			);
		}
	}
}
