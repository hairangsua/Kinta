using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinta.DAL;
using Kinta.Models;
using Kinta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            //bool b = _service.Insert(obj);
            //if (!b)
            //{
            //    return NotFound();
            //}

            //return b;

            return CategoryDAL.Insert(obj);
        }

        [HttpGet]
        [Route("GetCategoryItems")]
        public ActionResult<List<CategoryModel>> GetAll()
        {
            return _service.GetAll();
        }
    }
}