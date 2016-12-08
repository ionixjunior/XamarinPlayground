using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;

namespace Core.Fake
{
	public class ContactFake
	{
		private static IList<ContactModel> _data;
		private static IList<ContactModel> Data
		{
			get
			{
				if (_data == null)
				{
					_data = new List<ContactModel>();

					for (int i = 1; i <= 100; i++)
					{
						_data.Add(new ContactModel()
						{
							Id = Guid.NewGuid().ToString(),
							Name = $"Name {i}",
							Email = $"email{i}@domain.com",
							IsFavorite = false
						});
					}
				}
				
				return _data;
			}
		}

		public static IList<ContactModel> GetAll()
		{
			return Data;
		}

		public static ContactModel GetById(string id)
		{
			return GetAll().FirstOrDefault(d => d.Id == id);
		}

		public static ContactModel Update(
			string id, 
			string name, 
			string email, 
			bool isFavorite
		) {
			int index = Data.IndexOf(GetById(id));

			Data[index].Id = id;
			Data[index].Name = name;
			Data[index].Email = email;
			Data[index].IsFavorite= isFavorite;

			return Data[index];
		}
	}
}
