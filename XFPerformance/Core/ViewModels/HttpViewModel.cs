using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Models;
using Core.Services;
using Xamarin.Forms;
using System.Linq;

namespace Core.ViewModels
{
    public class HttpViewModel : BaseViewModel
    {
        public ICommand LoadCommand 
            => new Command<string>(async (type) => await Load(type));

        public ObservableCollection<ContactModel> Contacts { get; set; }

        public HttpViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>();
        }

        public async Task Load(string type)
        {
            if (IsBusy)
                return;
            
            try
            {
                IsBusy = true;
                Contacts.Clear();
                ObservableCollection<ContactModel> list = null;

                var start = DateTime.Now;

                if (type == "string")
                    list = new ObservableCollection<ContactModel>(await ContactService.Instance.GetContacts());

                if (type == "stream")
                    list = new ObservableCollection<ContactModel>(await ContactService.Instance.GetContactsFromStream());

                foreach (var item in list)
                    Contacts.Add(item);
                
                var end = DateTime.Now;

                var total = (end - start).TotalMilliseconds;
                System.Diagnostics.Debug.WriteLine($"Final: {total}");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
