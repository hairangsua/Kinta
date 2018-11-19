using Kinta.Application.Command;
using Kinta.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Kinta.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class PostItemsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostItemModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostItemsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}