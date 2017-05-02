using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Refit;

namespace Core.Interfaces
{
	[Headers(
		"Content-Type: application/json",
		"Authorization: Basic YWRtaW46MTIz"
	)]
	public interface IServerService
	{
		[Get("/contact")]
		Task<IList<ContactModel>> Get();

		[Post("/contact")]
		Task<ContactModel> Post(
			[Body] ContactModel contactModel
		);

		[Put("/contact/{id}")]
		Task<ContactModel> Put(
			[AliasAs("id")] string id, 
			ContactModel contactModel
		);

		[Delete("/contact/{id}")]
		Task Delete(
			[AliasAs("id")] string id
		);
	}
}
