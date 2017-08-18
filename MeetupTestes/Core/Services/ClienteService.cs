using System.Linq;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;
using SQLite;
using Xamarin.Forms;
using System;

namespace Core.Services
{
    public class ClienteService
    {
        private static ClienteService _instance;
        public static ClienteService Instance => _instance ?? (_instance = new ClienteService());

        private SQLiteConnection _conn;

        private ClienteService() 
        {
            _conn = DependencyService.Get<ISQLite>().GetConnection();
        }

        public IList<ClienteModel> CarregarDados(string filtro = null)
        {
            var query = _conn.Table<ClienteModel>();

            if (string.IsNullOrEmpty(filtro))
                return query.ToList();
            
            query = query.Where(
                c => c.Nome.ToLower().Contains(filtro.ToLower()) ||
                     c.Endereco.ToLower().Contains(filtro.ToLower()) ||
                     c.Telefone.ToLower().Contains(filtro.ToLower())
            );

            return query.ToList();
        }

        public void Salvar(ClienteModel clienteModel)
        {
            if (clienteModel.Id == null)
            {
                clienteModel.Id = Guid.NewGuid().ToString();
                clienteModel.CriadoEm = DateTime.Now;
            }

            _conn.InsertOrReplace(clienteModel);
        }

        public ClienteModel CarregarPorId(string id)
        {
            return _conn.Table<ClienteModel>().Where(c => c.Id == id).FirstOrDefault();
        }

        public void ApagarPorId(string id)
        {
            _conn.Delete<ClienteModel>(id);
        }
    }
}
