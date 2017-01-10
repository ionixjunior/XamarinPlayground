using System.Windows.Input;
using Xamarin.Forms;

namespace Core.Controls
{
	public class CustomContentPage : ContentPage
	{
		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create(
				nameof(Command),
				typeof(ICommand),
				typeof(CustomContentPage),
				null
			);

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}
	}
}
