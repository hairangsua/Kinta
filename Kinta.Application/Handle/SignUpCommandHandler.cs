using Kinta.Bussiness.BL;
using Kinta.Models.Command;
using Kinta.Models.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kinta.Bussiness.Handler
{
    public class SignUpCommandHandler : IRequestHandler<UserRegisterCommand, User>
    {
        public Task<User> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bl = new UserBL();

                //var user = Mapper.Map<User>(request.UserDTO);

                var user = new User
                {
                    Id = request.UserDTO.Id,
                    DisplayName = request.UserDTO.DisplayName,
                    FirstName = request.UserDTO.FirstName,
                    LastName = request.UserDTO.LastName,
                    Username = request.UserDTO.Username
                };

                return Task.FromResult(bl.Register(user, request.UserDTO.Password));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}