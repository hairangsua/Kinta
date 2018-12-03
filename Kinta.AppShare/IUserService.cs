using Kinta.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.AppShared
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(string id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
