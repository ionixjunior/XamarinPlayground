using System;
using System.IO;
using Core.Droid.Impl;
using Core.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteImpl))]
namespace Core.Droid.Impl
{
	public class SQLiteImpl : ISQLite
	{
		private string _databaseName = "meetup.db3";

		public SQLiteConnection GetConnection()
		{
			var databasePath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				_databaseName
			);

			return new SQLiteConnection(databasePath);
		}
	}
}
