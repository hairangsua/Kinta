using Kinta.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Models.Authentication
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(string id);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [DbName("user")]
    public class User : BaseModel
    {
        [DbColumn(Name = "id")]
        public int Id { get; set; }

        [DbColumn(Name = "first_name")]
        public string FirstName { get; set; }

        [DbColumn(Name = "last_name")]
        public string LastName { get; set; }

        [DbColumn(Name = "display_name")]
        public string DisplayName { get; set; }

        [DbColumn(Name = "username")]
        public string Username { get; set; }

        [DbColumn(Name = "password_hash")]
        public byte[] PasswordHash { get; set; }

        [DbColumn(Name = "password_salt")]
        public byte[] PasswordSalt { get; set; }
    }
}
