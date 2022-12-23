using Companions.AuthenticationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Companions.AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly JWTConfiguration _jwtConfig;

        public LogoutController(IConfiguration config)
        {
            _jwtConfig = config.GetSection("JWT").Get<JWTConfiguration>();
        }

        [HttpGet]
        [SwaggerOperation("Logs out the user by removing the HTTP Only Cookie")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "User logged out")]
        public IActionResult Logout()
        {
            Response.Cookies.Append(_jwtConfig.JWTHttpCookieName, $"", new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddHours(-1),
                Path = "/",
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            

            Response.Cookies.Append("Id", $"", new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddHours(-1),
                Path = "/",
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None
            });
            return Ok("User logged out");
        }
    }
}
