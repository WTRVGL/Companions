using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Companions.AuthenticationService.Services;
using Companions.AuthenticationService.Models;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Companions.AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly JWTConfiguration _jwtConfig;

        public LoginController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _jwtConfig = config.GetSection("JWT").Get<JWTConfiguration>();
        }

        // POST api/<AuthController>
        [HttpPost]
        [SwaggerOperation("Tries to authenticate an user and attaches a secure HTTP Only JWT token")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(User), Description = "Sucessfully authenticated the user. HTTP Only cookie attached.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Incompatible request body")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "User does not exist")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Incorrect password entered")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response =  _authService.AuthenticateUser(request);

            if (response == null)
            {
                return NotFound("User does not exist");
            }

            if(response.AuthStatus == "Not Authenticated")
            {
                return Unauthorized("Incorrect password entered");
            }

            Response.Cookies.Append(_jwtConfig.JWTHttpCookieName, $"{response.Token}", new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddHours(24),
                Path = "/",
                HttpOnly = true,
                Secure = true,
                SameSite= SameSiteMode.None
            });

            Response.Cookies.Append("Id", $"{response.User.Id}", new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddHours(24),
                Path = "/",
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None
            });


            return Ok(response.User);
        }

    }
}
