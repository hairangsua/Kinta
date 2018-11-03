using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helper;
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
            var dal = new CategoryDAL();
            obj.Id = IdHelper.NewGuid();
            obj.CreatedTime = DateTime.Now;
            obj.UpdatedTime = DateTime.Now;
            return dal.Insert(obj);
        }

        [HttpGet]
        [Route("GetCategoryItems")]
        public ActionResult<List<CategoryModel>> GetAll()
        {
            return _service.GetAll();
        }
    }
}