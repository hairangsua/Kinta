using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTestAuthentication
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SomeController : ControllerBase
    {
        private ISomeService _service;

        public SomeController(ISomeService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var something = _service.GetAll();
            return Ok();
        }

        [HttpPost]
        public IActionResult Insert([FromBody] SomeThingEntity entity)
        {
            _service.Insert(entity);
            return Ok();
        }
    }
}
