//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Net;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Kinta.Application.Command;
//using Kinta.Controllers;
//using Kinta.Domain;
//using Kinta.Models.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;

//namespace Kinta.Web.Controllers
//{
//    [Authorize]
//    public class UserController : BaseController
//    {
//        private IUserService _userService;
//        private IMapper _mapper;
//        private readonly AppSettings _appSettings;

//        public UserController(
//            IUserService userService,
//            IMapper mapper,
//            IOptions<AppSettings> appSettings)
//        {
//            _userService = userService;
//            _mapper = mapper;
//            _appSettings = appSettings.Value;
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> Register([FromQuery] SignUpCommand command)
//        {
//            command.UserModel = new UserModel
//            {
//                Id = 1232,
//                DisplayName = "Hải Hoàng Phi",
//                FirstName = "Hải",
//                LastName = "Hoàng Phi",
//                Password = "123456",
//                Username = "hai123"
//            };
//            return Ok(await Mediator.Send(command));
//        }

//        [AllowAnonymous]
//        [HttpPost("authenticate")]
//        public IActionResult Authenticate([FromBody]UserModel userModel)
//        {
//            var user = _userService.Authenticate(userModel.Username, userModel.Password);

//            if (user == null)
//                return BadRequest(new { message = "Username or password is incorrect" });

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[]
//                {
//                    new Claim(ClaimTypes.Name, user.Id.ToString())
//                }),
//                Expires = DateTime.UtcNow.AddDays(7),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            var tokenString = tokenHandler.WriteToken(token);

//            // return basic user info (without password) and token to store client side
//            return Ok(new
//            {
//                Id = user.Id,
//                Username = user.Username,
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Token = tokenString
//            });
//        }
//    }
//}