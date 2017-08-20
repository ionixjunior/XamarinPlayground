using System;
using System.IO;
using Core.Interfaces;
using SQLite;

namespace Core.iOS.Impl
{
    public class SQLiteImpl : ISQLite
    {
        private string _databaseName = "meetup.db3";

        public SQLiteConnection GetConnection()
        {
            var databasePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "..",
                "Library",
                _databaseName
            );

            return new SQLiteConnection(databasePath);
        }
    }
}
