using Kinta.Bussiness.BL;
using Kinta.Models.Command;
using Kinta.Models.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kinta.Bussiness.Handler
{
    public class UserAuthenticateCommandHandler : IRequestHandler<UserAuthenticateCommand, AuthenticateResult>
    {
        public Task<AuthenticateResult> Handle(UserAuthenticateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bl = new UserBL();

                //var user = Mapper.Map<User>(request.UserDTO);

                var rs = bl.Authenticate(request.Username, request.Password);

                return Task.FromResult(rs);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}