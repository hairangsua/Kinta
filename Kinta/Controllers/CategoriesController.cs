using Kinta.Common.Helper;
using Kinta.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Kinta.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ////private readonly IService<CategoryModel> _service;

        //public CategoriesController(/*IService<CategoryModel> service*/)
        //{
        //    //_service = service;
        //}

        //[HttpPost]
        //[Route("InsertCategoryItems")]
        //public ActionResult<bool> Insert(CategoryModel obj)
        //{
        //    obj.Id = IdHelper.NewGuid();
        //    MySqlConnection myConnection = new MySqlConnection("Data Source=35.236.185.220;Port=3306;User=root;Password=nghia1996;Initial Catalog=kinta)";
        //    return _service.Insert(obj);
        //}

        //[HttpGet]
        //[Route("GetCategoryItems")]
        //public ActionResult<List<CategoryModel>> GetAll()
        //{
        //    return _service.FindAll();
        //}
    }
}