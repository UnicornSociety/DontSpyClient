using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DontSpy.Interfaces;
using DontSpy.Model;
using Newtonsoft.Json;

namespace DontSpy.Service
{
    internal class RestService : IRestService
    {
        private readonly HttpClient _client;

        public RestService()
        {
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("y:123")));
        }

        public async Task<bool> CreateOwnUser(User user)
        {
            try
            {
                var validateUsername = GetUserBy(user.Username).Result;
                if (validateUsername != null) return false;
                var uri = new Uri(string.Format(Constants.RestUrlNewUser));
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                return true;
            }
            catch // TODO: Improve error management
            {
                Debug.WriteLine("Server antwortet nicht");
                return false;
            }
        }

        public async Task<User> GetUserBy(string username)
        {
            var uri = new Uri(string.Format(Constants.RestUrlGetUser, username));
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            return null;
        }

        public async Task<bool> SendMessage(Message message)
        {
            try
            {
                var uri = new Uri(string.Format(Constants.RestUrlSendMessage));
                var json = JsonConvert.SerializeObject(message);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                return true;
            }
            catch // TODO: Improve error management
            {
                Debug.WriteLine("Server antwortet nicht");
                return false;
            }
        }

        public async Task<List<Message>> GetMessageBy(string channelId)
        {
            var messages = new List<Message>();

            var uri = new Uri(string.Format(Constants.RestUrlGetMessage, channelId));
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                messages = JsonConvert.DeserializeObject<List<Message>>(content);
            }

            return messages;
        }

        public async Task<bool> UpdateMessageProcessingCounterBy(string id)
        {
            var uri = new Uri(string.Format(Constants.RestUrlUpdateMessageProcessingCounter, id));
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                // Do nothing
            }

            return true;
        }

        public async Task<bool> DeleteMessageBy(string id)
        {
            var uri = new Uri(string.Format(Constants.RestUrlDeleteMessage, id));
            var response = await _client.DeleteAsync(uri);
            return true;
        }
    }
}
