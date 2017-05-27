using System.Collections.ObjectModel;
using Core.Models;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public Command ClickCommand => new Command(Click);
        public ObservableCollection<ContactModel> Contacts { get; set; }

        public ListViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>();

            int imageIndex = 1;
            for (int i = 0; i <= 100; i++)
            {
                Contacts.Add(new ContactModel()
                {
                    FirstName = $"Nome {i}",
                    Email = $"email{i}@email.com",
                    Address = $"Rua {i}, n {i}",
                    Twitter = $"@useraccount{i}",
                    Image = $"img{imageIndex}.png"
                });

                if (imageIndex == 10)
                    imageIndex = 1;
                else
                    imageIndex++;
            }
        }

        private void Click()
        {
            System.Diagnostics.Debug.WriteLine("click");
        }
    }
}
