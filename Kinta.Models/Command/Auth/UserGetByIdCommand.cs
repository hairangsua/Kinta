using Kinta.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Models.Command
{
    public class UserGetByIdCommand : IRequest<User>
    {
        public string Id { get; set; }        
    }
}
