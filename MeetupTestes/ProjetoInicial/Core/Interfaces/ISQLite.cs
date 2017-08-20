using SQLite;

namespace Core.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
