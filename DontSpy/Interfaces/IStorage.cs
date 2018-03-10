using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;

namespace DontSpy.Interfaces
{
    public interface IStorage
    {
        void CloseConnection();
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
        bool SetValueWithKey(string key, string value);
        string GetValueFromKey(string key, string defaultValue = null);
        bool DeleteValueFromKey(string key);
        bool CheckValueFromKeyExists(string key);
        bool ClearKeyValueStorage();
        Task<string> SaveImage(string filename, byte[] stream);
    }
}
