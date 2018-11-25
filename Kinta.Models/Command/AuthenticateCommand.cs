using Kinta.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Models.Command
{
    public class AuthenticateCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
