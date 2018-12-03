using AutoMapper;
using Kinta.AppShared;
using Kinta.Controllers;
using Kinta.Framework.Data.Entity;
using Kinta.Models.Command;
using Kinta.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kinta.Web.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        //private IUserService _userService;
        //private IMapper _mapper;
        //private readonly AppSettings _appSettings;

        //public UserController()
        //{

        //}

        //public IActionResult Create([FromBody]UserDTO userDTO)
        //{
        //    return Ok(_userService.Create(new User
        //    {
        //        Id = userDTO.Id,
        //        DisplayName = userDTO.DisplayName,
        //        FirstName = userDTO.FirstName,
        //        LastName = userDTO.LastName,
        //        Username = userDTO.Username
        //    }, userDTO.Password));
        //}

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticateCommand cmd)
        {
            return Ok(await Mediator.Send(cmd));
        }

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody]UserDTO userDTO)
        //{
        //    var user = _userService.Authenticate(userDTO.Username, userDTO.Password);

        //    if (user == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    // return basic user info (without password) and token to store client side
        //    return Ok(new
        //    {
        //        Id = user.Id,
        //        Username = user.Username,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Token = tokenString
        //    });
        //}
    }
}