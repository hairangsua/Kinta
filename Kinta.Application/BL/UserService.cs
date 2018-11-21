using Kinta.Application.DAL;
using Kinta.Common.Helper;
using Kinta.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.BL
{
    public class UserService : IUserService
    {
        //public UserRepo Repo { get { return _repo; } }
        private UserRepo _repo;

        public UserService()
        {
            _repo = new UserRepo();
        }

        public User Authenticate(string username, string password)
        {
            if (username.IsEmpty() || password.IsEmpty())
            {
                return null;
            }

            var user = _repo.SingleOrDefault(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            throw new NotImplementedException();
        }

        public User Create(User user, string password)
        {
            // validation
            if (password.IsNullOrWhiteSpace())
                throw new Exception("Password is required");

            var userName = user.Username;
            var existed = _repo.SingleOrDefault(x => x.Username == userName);
            if (existed != null)
                throw new Exception("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _repo.Insert(user);

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user, string password = null)
        {
            throw new NotImplementedException();
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password.IsEmpty())
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (password.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            }

            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerHash.Length; i++)
                {
                    if (computerHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
