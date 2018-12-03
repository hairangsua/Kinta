using Kinta.Bussiness.BL;
using Kinta.Models.Command;
using Kinta.Models.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kinta.Bussiness.Handler
{
    public class UserGetByIdCommandHandler : IRequestHandler<UserGetByIdCommand, User>
    {
        public Task<User> Handle(UserGetByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bl = new UserBL();
                return Task.FromResult(bl.GetById(request.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}