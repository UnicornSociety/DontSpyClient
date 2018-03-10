using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontSpy.Interfaces;
using Plugin.SecureStorage;
using SQLite.Net;
using SQLite.Net.Async;

namespace DontSpy.Service
{
    public class StorageService : IStorage
    {
        private Dictionary<string, string> _keyValuesWithinStorage = new Dictionary<string, string>();

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

        public bool SetValueWithKey(string key, string value)
        {
            if (!CrossSecureStorage.Current.SetValue(key, value)) return false;

            if (!_keyValuesWithinStorage.ContainsKey(key))
            {
                _keyValuesWithinStorage.Add(key, value);
            }
            else
            {
                _keyValuesWithinStorage[key] = value; // Overwrite key
            }

            return true;
        }

        public string GetValueFromKey(string key, string defaultValue = null)
        {
            return CrossSecureStorage.Current.GetValue(key, defaultValue);
        }

        public bool DeleteValueFromKey(string key)
        {
            return CrossSecureStorage.Current.DeleteKey(key) && _keyValuesWithinStorage.Remove(key);
        }

        public bool CheckValueFromKeyExists(string key)
        {
            return CrossSecureStorage.Current.HasKey(key);
        }

        public bool ClearKeyValueStorage()
        {
            var success = true;

            foreach (var keyForValueToDelete in _keyValuesWithinStorage.Keys.ToList())
            {
                if (!CrossSecureStorage.Current.DeleteKey(keyForValueToDelete)) success = false;
                if (!_keyValuesWithinStorage.Remove(keyForValueToDelete)) success = false;
            }

            return success;
        }

        public Task<string> SaveImage(string filename, byte[] stream)
        {
            throw new System.NotImplementedException();
        }
    }
}
