using System;
using System.Collections.ObjectModel;
using Core.Models;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        public ObservableCollection<ClienteModel> Clientes { get; private set; }

        public Command CarregaDadosCommand 
            => new Command(CarregaDados);

        public ClienteViewModel()
        {
        }

        public override void Init()
        {
            if (CarregaDadosCommand.CanExecute(null))
                CarregaDadosCommand.Execute(null);
        }

        private void CarregaDados()
        {
            System.Diagnostics.Debug.WriteLine("Carrega dados");
        }
    }
}
