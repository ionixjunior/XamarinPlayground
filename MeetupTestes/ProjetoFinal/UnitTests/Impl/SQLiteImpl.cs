using System;
using System.IO;
using Core.Interfaces;
using SQLite;

namespace Core.UnitTests.Impl
{
    public class SQLiteImpl : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var databasePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..",
                "..",
                "database",
                "testes.db"
            );

            return new SQLiteConnection(databasePath);
        }
    }
}
