using Kinta.Bussiness.DAL;
using Kinta.Framework;
using Kinta.Framework.BaseExceptions;
using Kinta.Framework.Exceptions;
using Kinta.Framework.Helper;
using Kinta.Models.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kinta.Bussiness.BL
{
    public class UserBL
    {

        private UserRepo _repo;

        public UserBL()
        {
            _repo = new UserRepo();
        }

        public AuthenticateResult Authenticate(string username, string password)
        {
            var rs = new AuthenticateResult();
            if (username.IsEmpty() || password.IsEmpty())
            {
                return null;
            }

            var user = _repo.SingleOrDefault(x => x.Username == username);

            if (user == null)
            {
                throw new AuthenticateException("username is not existed");
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new AuthenticateException("username or password not match");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthConstant.SecretKey.Code);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            rs.Token = tokenString;
            rs.User = user;

            return rs;
        }

        public User Register(User user, string password)
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

        public User GetById(string id)
        {
            if (id.IsEmpty())
            {
                throw new Exception("Id Không tồn tại trong hệ thống");
            }

            return _repo.SingleOrDefault(x => x.Id == id);
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
