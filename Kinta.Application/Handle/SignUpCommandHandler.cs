//using AutoMapper;
//using Kinta.Application.BL;
//using Kinta.Application.Command;
//using Kinta.Models.Authentication;
//using Kinta.Models.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Kinta.Bussiness.Handler
//{
//    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, User>
//    {
//        public Task<User> Handle(SignUpCommand request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var userService = new UserService();

//                //var user = Mapper.Map<User>(request.UserModel);

//                var user = new User
//                {
//                    Id = request.UserModel.Id,
//                    DisplayName = request.UserModel.DisplayName,
//                    FirstName = request.UserModel.FirstName,
//                    LastName = request.UserModel.LastName,
//                    Username = request.UserModel.Username
//                };

//                return Task.FromResult(userService.Create(user, request.UserModel.Password));
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }
//    }
//}