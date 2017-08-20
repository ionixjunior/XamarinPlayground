using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Helpers;
using Core.Models;
using Core.Services;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        private readonly ClienteService _clienteService;
        private readonly NavigationHelper _navigation;

        private string _filtro;
        public string Filtro
        {
            get => _filtro;
            set
            {
                _filtro = value;

                if (CarregarDadosCommand.CanExecute(null))
                    CarregarDadosCommand.Execute(null);
            }
        }

        public ObservableCollection<ClienteModel> Clientes { get; private set; }

        public ICommand CarregarDadosCommand 
            => new Command(CarregarDados);

        public ICommand CadastrarCommand 
            => new Command(async () => await Cadastrar());

        public ICommand SelecionaItemCommand
            => new Command<ClienteModel>(async (item) => await SelecionaItem(item));

        public ClienteViewModel()
        {
            _clienteService = ClienteService.Instance;
            _navigation = NavigationHelper.Instance;
            Clientes = new ObservableCollection<ClienteModel>();
        }

        public override void Init()
        {
            if (CarregarDadosCommand.CanExecute(null))
                CarregarDadosCommand.Execute(null);
        }

        private void CarregarDados()
        {
            try
            {
                Clientes.Clear();

                foreach (var cliente in _clienteService.CarregarDados(Filtro))
                    Clientes.Add(cliente);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        private async Task Cadastrar()
        {
            await _navigation.NavigateAsync<ClienteDetalheViewModel>("Cadastro");
        }

        private async Task SelecionaItem(ClienteModel clienteModel)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add(ClienteDetalheViewModel.ID, clienteModel.Id);
            await _navigation.NavigateAsync<ClienteDetalheViewModel>("Editar", parameters);
        }
    }
}
