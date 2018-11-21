using System;
using System.Collections.Generic;
using System.Text;
using Kinta.Models.Authentication;
using MediatR;

namespace Kinta.Application.Command
{
    public class SignUpCommand : IRequest<User>
    {
        public UserModel UserModel { get; set; }
    }
}
