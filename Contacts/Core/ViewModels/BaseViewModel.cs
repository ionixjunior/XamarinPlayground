using PropertyChanged;

namespace Core.ViewModels
{
	[ImplementPropertyChanged]
	public abstract class BaseViewModel
	{
		public bool IsBusy { get; set; }
	}
}
