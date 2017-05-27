using Core.Models;

namespace Core.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
		public ContactModel _contact { get; set; }
		public ContactModel Contact
		{
			get { return _contact; }
			set
			{
				_contact = value;
				OnPropertyChanged();
			}
		}

		public DetailViewModel()
		{
			var contactModel = new ContactModel();
			contactModel.SetDefault();
			Contact = contactModel;
		}
    }
}
