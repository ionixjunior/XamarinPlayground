using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace Core.ViewModels
{
	[ImplementPropertyChanged]
	public class OptionViewModel
	{
		public ICommand CloseCommand 
			=> new Command(async () => await Close());

		private async Task Close()
		{
			await Application.Current.MainPage.Navigation.PopModalAsync();
		}
	}
}
