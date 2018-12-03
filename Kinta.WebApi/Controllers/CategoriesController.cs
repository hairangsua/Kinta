using Kinta.Models.Command;
using Kinta.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Kinta.AppShared.Authorize;

namespace Kinta.Controllers
{
    //[MyServiceAuthorize]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}