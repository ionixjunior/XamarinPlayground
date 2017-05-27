using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Services
{
    public class ContactService
    {
        private static ContactService _instance;
        public static ContactService Instance => _instance ?? (_instance = new ContactService());

        private HttpClient _httpClient;
        private JsonSerializer _jsonSerializer;

        private ContactService()
        {
            _httpClient = new HttpClient();
            _jsonSerializer = new JsonSerializer();
        }

        public async Task<IList<ContactModel>> GetContacts()
        {
            System.Diagnostics.Debug.WriteLine("load from string");
            var request = new HttpRequestMessage(
                HttpMethod.Get, 
                "http://192.168.0.12:3000/contact"
            );
            request.Headers.Add("Cache-Control", "no-cache");

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode == false)
                throw new Exception(response.ReasonPhrase);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IList<ContactModel>>(json);
        }

		public async Task<IList<ContactModel>> GetContactsFromStream()
		{
            System.Diagnostics.Debug.WriteLine("load from stream");
			var request = new HttpRequestMessage(
				HttpMethod.Get,
				"http://192.168.0.12:3000/contact"
			);
            request.Headers.Add("Cache-Control", "no-cache");

			var response = await _httpClient.SendAsync(request);
			if (response.IsSuccessStatusCode == false)
				throw new Exception(response.ReasonPhrase);

            using (var stream = await response.Content.ReadAsStreamAsync())
			using (var reader = new StreamReader(stream))
			using (var json = new JsonTextReader(reader))
			{
                return _jsonSerializer.Deserialize<IList<ContactModel>>(json);
			}
		}
    }
}
