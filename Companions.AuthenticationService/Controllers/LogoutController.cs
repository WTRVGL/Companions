using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Append("JWTkoek", $"", new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddHours(-1),
                Path = "/",
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            

            Response.Cookies.Append("scopelandId", $"", new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddHours(-1),
                Path = "/",
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None
            });
            return Ok();
        }
    }
}
