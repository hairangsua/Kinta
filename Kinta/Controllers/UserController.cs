using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kinta.Application.Command;
using Kinta.Controllers;
using Kinta.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Kinta.Web.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromQuery] SignUpCommand command)
        {
            command.UserModel = new UserModel
            {
                Id = 1232,
                DisplayName = "Hải Hoàng Phi",
                FirstName = "Hải",
                LastName = "Hoàng Phi",
                Password = "123456",
                Username = "hai123"
            };
            return Ok(await Mediator.Send(command));
        }
    }
}