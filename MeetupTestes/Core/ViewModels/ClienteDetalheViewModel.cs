using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Helpers;
using Core.Models;
using Core.Services;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class ClienteDetalheViewModel : BaseViewModel
    {
        public const string ID = "ID";

        private readonly ClienteService _clienteService;
        private readonly NavigationHelper _navigation;

        private ClienteModel _clienteModel;

        private bool _edicao;
        public bool Edicao
        {
            get => _edicao;
            set
            {
                _edicao = value;
                OnPropertyChanged();
            }
        }

        private string _nome;
		public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        private string _endereco;
		public string Endereco
        {
            get => _endereco;
            set
            {
                _endereco = value;
                OnPropertyChanged();
            }
        }

        private string _email;
		public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _telefone;
		public string Telefone
        {
            get => _telefone;
            set
            {
                _telefone = value;
                OnPropertyChanged();
            }
        }

        private DateTime _criadoEm;
		public DateTime CriadoEm
        {
            get => _criadoEm;
            set
            {
                _criadoEm = value;
                OnPropertyChanged();
            }
        }

        public Command SalvarCommand 
            => new Command(async () => await Salvar());

        public Command ApagarCommand
            => new Command(async () => await Apagar());

        public ClienteDetalheViewModel()
        {
            _clienteService = ClienteService.Instance;
            _navigation = NavigationHelper.Instance;
        }

        public override void Init()
        {
            _clienteModel = new ClienteModel();
            Edicao = false;
        }

        public override void Init(Dictionary<string, string> parametros)
        {
            if (parametros.ContainsKey(ID))
                _clienteModel = _clienteService.CarregarPorId(parametros[ID]);

            if (_clienteModel == null)
            {
                Init();
                return;
            }

            Nome = _clienteModel.Nome;
            Endereco = _clienteModel.Endereco;
            Email = _clienteModel.Email;
            Telefone = _clienteModel.Telefone;
            CriadoEm = _clienteModel.CriadoEm;
            Edicao = true;
        }

        private async Task Salvar()
        {
            try
            {
                _clienteModel.Nome = Nome;
                _clienteModel.Endereco = Endereco;
                _clienteModel.Email = Email;
                _clienteModel.Telefone = Telefone;

                _clienteService.Salvar(_clienteModel);
                await _navigation.BackAsync<ClienteViewModel>(vm => vm.Init());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        private async Task Apagar()
        {
            try
            {
                _clienteService.ApagarPorId(_clienteModel.Id);
                await _navigation.BackAsync<ClienteViewModel>(vm => vm.Init());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
