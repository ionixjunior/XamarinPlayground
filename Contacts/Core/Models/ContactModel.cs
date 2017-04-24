using Newtonsoft.Json;

namespace Core.Models
{
	public class ContactModel
	{
		[JsonProperty("_id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }
	}
}
