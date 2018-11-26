using Kinta.AppShared;
using Kinta.Controllers;
using Kinta.Models.Command;
using Kinta.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kinta.WebApi.Services
{
    public class UserService : BaseController, IUserService
    {
        //[AllowAnonymous]
        public User Authenticate(string username, string password)
        {
            var command = new AuthenticateCommand();
            command.Username = username;
            command.Password = password;
            return Mediator.Send(command).Result;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public User Create(User user, string password)
        {
            SignUpCommand command = new SignUpCommand();

            command.UserDTO = new UserDTO
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = password,
                Username = user.Username
            };
            return Mediator.Send(command).Result;
        }

        public void Delete(int id)
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
    }
}
