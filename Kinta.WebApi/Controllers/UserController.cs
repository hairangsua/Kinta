using Kinta.Controllers;
using Kinta.Models.Command;
using Kinta.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Kinta.Web.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), (int)HttpStatusCode.OK)]
        public IActionResult Register([FromBody] UserRegisterCommand cmd)
        {
            return Ok(Mediator.Send(cmd));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticateCommand cmd)
        {
            return Ok(await Mediator.Send(cmd));
        }     
    }
}