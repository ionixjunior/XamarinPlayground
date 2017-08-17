using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Core.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Init() {}
        public virtual void Init(Dictionary<string, string> parametros) {}
        public virtual void OnAppearing() {}
        public virtual void OnDisappearing() {}
    }
}
