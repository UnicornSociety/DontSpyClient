﻿using System.Threading.Tasks;
using ModernEncryption.Model;

namespace ModernEncryption.Interfaces
{
    internal interface IUserService
    {
        Task<User> GetUser(string eMail);
        Task<bool> NewUser(User user);
    }
}
