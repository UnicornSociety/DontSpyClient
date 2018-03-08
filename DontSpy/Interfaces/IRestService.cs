﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DontSpy.Model;

namespace DontSpy.Interfaces
{
    internal interface IRestService
    {
        Task<bool> CreateOwnUser(User user);
        Task<User> GetUserBy(string username);
        Task<bool> SendMessage(Message message);
        Task<List<Message>> GetMessageBy(string channelId);
        Task<bool> UpdateMessageProcessingCounterBy(string id);
        Task<bool> DeleteMessageBy(string id);
    }
}
