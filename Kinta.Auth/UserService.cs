using Kinta.AppShared;
using Kinta.Models.Command;
using Kinta.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Kinta.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private IMediator _mediator;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = _httpContextAccessor.HttpContext.RequestServices.GetService<IMediator>();
        }

        public User Authenticate(string username, string password)
        {
            var command = new UserAuthenticateCommand();
            command.Username = username;
            command.Password = password;
            return _mediator.Send(command).Result.User;
        }

        public User Create(User user, string password)
        {
            UserRegisterCommand command = new UserRegisterCommand();

            command.UserDTO = new UserDTO
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = password,
                Username = user.Username
            };
            return _mediator.Send(command).Result;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(string id)
        {
            var rs = _mediator.Send(new UserGetByIdCommand { Id = id });
            return rs.Result;
        }

        public void Update(User user, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}
