using Kinta.Application.Models;
using Kinta.Common.Helper;
using Kinta.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kinta.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IService<CategoryModel> _service;

        public CategoriesController(IService<CategoryModel> service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("InsertCategoryItems")]
        public ActionResult<bool> Insert(CategoryModel obj)
        {
            obj.Id = IdHelper.NewGuid();
            return _service.Insert(obj);
        }

        [HttpGet]
        [Route("GetCategoryItems")]
        public ActionResult<List<CategoryModel>> GetAll()
        {
            return _service.FindAll();
        }
    }
}