using SQLite;

namespace zerox.core
{
    public interface IDb
    {
        SQLiteConnection GetConnection(string dbName);
    }
}
