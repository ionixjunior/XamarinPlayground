using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Refit;

namespace Core.Services
{
	public class RefitService : IServerService
	{
		private IServerService _server;

		public RefitService()
		{
			_server = RestService.For<IServerService>(
				AppConfig.RestApiBaseUrl
			);
		}

		public async Task<IList<ContactModel>> Get()
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			return await _server.Get();
		}

		public async Task<ContactModel> Post(ContactModel contactModel)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			return await _server.Post(contactModel);
		}

		public async Task<ContactModel> Put(string id, ContactModel contactModel)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			return await _server.Put(id, contactModel);
		}

		public async Task Delete(string id)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			await _server.Delete(id);
		}
	}
}
