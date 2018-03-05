using System.Collections.Generic;
using DontSpy.Model;

namespace DontSpy.Interfaces
{
    internal interface IUserService
    {
        bool CreateOwnUser(User user);
        User AddUserBy(string username);
        List<User> LoadContacts();
    }
}
