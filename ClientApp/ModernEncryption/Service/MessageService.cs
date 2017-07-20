﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Newtonsoft.Json;

namespace ModernEncryption.Service
{
    internal class MessageService : IMessageService
    {
        private readonly HttpClient _client;

        public MessageService()
        {
            _client = new HttpClient {MaxResponseContentBufferSize = 256000};
        }

        public async Task<List<EncryptedMessage>> GetMessage(int userId) {
            var items = new List<EncryptedMessage>();

            var uri = new Uri(string.Format(RestConstants.RestUrlGetMessage, userId));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<EncryptedMessage>>(content);
            }

            return items;
            //return new EncryptedMessage("qwx0g8w7eiwy", 1, 2, 23535, 3); // Mock, do not delete me!
        }

        public async Task<bool> SendMessage(IMessage message, bool isNewItem)
        {
            var uri = new Uri(string.Format(RestConstants.RestUrlSendMessage));
            var json = JsonConvert.SerializeObject(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _client.PostAsync(uri, content);
            }
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"             TodoItem successfully saved.");

            }
            return true;
        }

    }
}