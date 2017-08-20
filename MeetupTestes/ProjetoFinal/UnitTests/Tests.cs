using System;
using System.IO;
using System.Linq;
using Core.ViewModels;
using NUnit.Framework;
using Autofac;
using Core.Models;
using Core.Services;

namespace Core.UnitTests
{
    public class Tests : BaseTest
    {
        private ClienteViewModel _vm;
        private ClienteService _clienteService;

        [SetUp]
        public void BeforeEachTest()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                _vm = scope.Resolve<ClienteViewModel>();
                _clienteService = scope.Resolve<ClienteService>();
            }
        }

        [Test]
        public void CarregarDados()
        {
            _vm.CarregarDadosCommand.Execute(null);
            Assert.AreEqual(0, _vm.Clientes.Count);

            var clienteModel = new ClienteModel()
            {
                Nome = "CLIENTE TESTE",
                Endereco = "RUA TESTE, 123",
                Email = "teste@teste.com.br",
                Telefone = "01199887766"
            };
            _clienteService.Salvar(clienteModel);

			_vm.CarregarDadosCommand.Execute(null);
			Assert.AreEqual(1, _vm.Clientes.Count);
        }

        [Test]
        public void Filtro()
        {
            for (var i = 1; i <= 5; i++)
            {
				var clienteModel = new ClienteModel()
				{
                    Nome = $"CLIENTE {i}",
                    Endereco = $"RUA TESTE, {i}",
                    Email = $"teste{i}@teste.com.br",
                    Telefone = $"0({i})99887766"
				};
				_clienteService.Salvar(clienteModel);
            }

			_vm.CarregarDadosCommand.Execute(null);
			Assert.AreEqual(5, _vm.Clientes.Count);

            _vm.Filtro = "cliente 1";
			_vm.CarregarDadosCommand.Execute(null);
			Assert.AreEqual(1, _vm.Clientes.Count);
        }
    }
}
