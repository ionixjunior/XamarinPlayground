using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Services
{
	public class HttpClientService : IServerService
	{
		private HttpClient _httpClient;
		private string _token = "YWRtaW46MTIz";

		public HttpClientService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<IList<ContactModel>> Get()
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");

			string url = $"{AppConfig.RestApiBaseUrl}/contact";

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			request.Headers.Add("Authorization", $"Basic {_token}");
			HttpResponseMessage response = await _httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode == false)
				throw new Exception(response.ReasonPhrase);

			string result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<IList<ContactModel>>(result);
		}

		public async Task<ContactModel> Post(ContactModel contactModel)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");

			string url = $"{AppConfig.RestApiBaseUrl}/contact";

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Headers.Add("Authorization", $"Basic {_token}");
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Content = new StringContent(
				JsonConvert.SerializeObject(contactModel), 
				Encoding.UTF8, 
				"application/json"
			);
			HttpResponseMessage response = await _httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode == false)
				throw new Exception(response.ReasonPhrase);
			
			string result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ContactModel>(result);
		}

		public async Task<ContactModel> Put(string id, ContactModel contactModel)
		{
			System.Diagnostics.Debug.WriteLine($"Implementation: {this.GetType().Name}");

			string url = $"{AppConfig.RestApiBaseUrl}/contact/{id}";

			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
			request.Headers.Add("Authorization", $"Basic {_token}");
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Content = new StringContent(
				JsonConvert.SerializeObject(contactModel), 
				Encoding.UTF8, 
				"application/json"
			);
			HttpResponseMessage response = await _httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode == false)
				throw new Exception(response.ReasonPhrase);
			
			string result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ContactModel>(result);
		}

		public async Task Delete(string id)
		{
			string url = $"{AppConfig.RestApiBaseUrl}/contact/{id}";

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
			request.Headers.Add("Authorization", $"Basic {_token}");
			HttpResponseMessage response = await _httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode == false)
				throw new Exception(response.ReasonPhrase);
		}
	}
}
