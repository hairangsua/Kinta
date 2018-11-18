using Kinta.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kinta.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class PostItemsController : ControllerBase
    {
        //private readonly IService<PostItemModel> _service;

        //public PostItemsController(IService<PostItemModel> service)
        //{
        //    _service = service;
        //}

        //[HttpPost]
        //[Route("Insert")]
        //public ActionResult<bool> Insert(PostItemModel obj)
        //{
        //    return _service.Insert(obj);
        //}

        //[HttpGet]
        //[Route("GetAll")]
        //public ActionResult<List<PostItemModel>> GetAll()
        //{
        //    return _service.FindAll();
        //}
    }
}