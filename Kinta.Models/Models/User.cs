using Kinta.Framework.Data;
using Kinta.Framework.Data.MappingAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Models.Models
{
    [DbName("user")]
    public class User : BaseModel, IUserProfile
    {
        [DbColumn(Name = "id")]
        public string Id { get; set; }

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

    public class UserDTO : IUserProfile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IUserProfile
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string DisplayName { get; set; }
        string Username { get; set; }
    }

    public class AuthenticateResult
    {
        public IUserProfile User { get; set; }
        public string Token { get; set; }
    }
}
