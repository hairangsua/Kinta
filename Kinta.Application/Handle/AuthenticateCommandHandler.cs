using Kinta.Bussiness.BL;
using Kinta.Models.Command;
using Kinta.Models.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kinta.Bussiness.Handler
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, User>
    {
        public Task<User> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bl = new UserBL();

                //var user = Mapper.Map<User>(request.UserDTO);

                return Task.FromResult(bl.Authenticate(request.Username, request.Password));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}