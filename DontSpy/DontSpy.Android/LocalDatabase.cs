using SQLite.Net;
using SQLite.Net.Async;

[assembly: Xamarin.Forms.Dependency(typeof(DontSpy.Droid.LocalDatabase))]
namespace DontSpy.Droid
{
    public class LocalDatabase : Interfaces.IStorage
    {
        public void CloseConnection()
        {
            throw new System.NotImplementedException();
        }

        public SQLiteConnection GetConnection()
        {
            throw new System.NotImplementedException();
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDatabase()
        {
            throw new System.NotImplementedException();
        }
    }
}