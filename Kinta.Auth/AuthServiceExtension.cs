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
        const string SecretKey = "xkc!@#dsm89d1283jd8asdsAD@#$qdasdh1312#2^dsad@";
        public static void InitAuthService(this IServiceCollection services)
        {
            try
            {
                services.AddScoped<IUserService, UserService>();

                var key = Encoding.ASCII.GetBytes(SecretKey);
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
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
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
