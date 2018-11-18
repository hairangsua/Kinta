using Kinta.Application.Command;
using Kinta.Common.Helper;
using Kinta.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;

namespace Kinta.Controllers
{

    public class CategoriesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQuery query)
        {
            var a = await Mediator.Send(query);            
            return Ok(await Mediator.Send(query));
        }
    }
}