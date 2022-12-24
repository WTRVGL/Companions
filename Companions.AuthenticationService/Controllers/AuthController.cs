using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;
using Companions.AuthenticationService.Services;
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
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        private readonly JWTConfiguration _jwtConfig;
        public AuthController(IUserRepository userRepository, ITokenService tokenService, IConfiguration config)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;

            _jwtConfig = config.GetSection("JWT").Get<JWTConfiguration>();
        }

        [HttpGet]
        [SwaggerOperation("Extracts JWT from HTTP Only Cookie and returns a user")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(User), Description = "User authenticated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "No user found")]
        public async Task<IActionResult> CheckAuthentication()
        {
            var x = HttpContext;
            var token = HttpContext.Request.Cookies[_jwtConfig.JWTHttpCookieName];

            if (token == null) return NotFound("No user found");

            var decodedToken = _tokenService.DecodeJwtSecurityToken(token);
            var id = decodedToken.Claims.FirstOrDefault(claim => claim.Type == "id");

            var user = _userRepository.GetUser(Convert.ToInt32(id.Value));


            return Ok(user);
        }
    }
}
