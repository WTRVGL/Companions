using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;
using Companions.AuthenticationService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [SwaggerOperation("Returns a User from a JWT")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(User), Description = "User authenticated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "No user found")]
        [Authorize]
        public async Task<ActionResult<User>> CheckAuthentication()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;

            var user = await _userRepository.GetUserById(userId);

            return Ok(user);
        }
    }
}
