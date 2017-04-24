using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Refit;

namespace Core.Services
{
	public class RefitService : IServerService
	{
		private IServerService _refit;
		private IServerService Refit 
			=> _refit ?? (_refit = RestService.For<IServerService>(AppConfig.RestApiBaseUrl));

		public async Task<IList<ContactModel>> GetContacts()
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			return await Refit.GetContacts();
		}

		public async Task<ContactModel> Insert(ContactModel contactModel)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			return await Refit.Insert(contactModel);
		}

		public async Task<ContactModel> Update(string id, ContactModel contactModel)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			return await Refit.Update(id, contactModel);
		}

		public async Task Delete(string id)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");
			await Refit.Delete(id);
		}
	}
}
