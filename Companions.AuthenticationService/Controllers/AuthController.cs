using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;
using Companions.AuthenticationService.Services;
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
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult CheckAuthentication()
        {
            var token = HttpContext.Request.Cookies["JWTkoek"];

            if (token == null) return Ok(new Gebruiker { Email = null});

            var decodedToken = _tokenService.decodeJwtSecurityToken(token);
            var id = decodedToken.Claims.FirstOrDefault(claim => claim.Type == "id");

            var user = _userRepository.GetUser(Convert.ToInt32(id.Value));


            return Ok(user);
        }
    }
}
