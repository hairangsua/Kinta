using Kinta.AppShared;
using Kinta.Auth.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Kinta.Auth.Extension
{
    public static class AuthServiceExtension
    {
        public static void InitAuthService(this IServiceCollection services)
        {
            try
            {
                services.AddScoped<IUserService, UserService>();

                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            //var userId = int.Parse(context.Principal.Identity.Name);                        
                            var user = userService.GetById(context.Principal.Identity.Name);
                            if (user == null)
                            {
                                //return unauthorized if user no longer exists
                                context.Fail("Unauthorized");
                            }
                            return Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {
                            //TODO: log here
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            //context.Fail("Token invalid");
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false; // TRUE ON PRODUCT
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthConstant.SecretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
