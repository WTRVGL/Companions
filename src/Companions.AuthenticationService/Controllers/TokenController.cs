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
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JWTConfiguration _jwtConfig;

        public TokenController(IAuthService authService, IConfiguration config, IConfiguration configuration)
        {
            _authService = authService;
            _jwtConfig = config.GetSection("JWT").Get<JWTConfiguration>();
        }

        // POST api/<AuthController>
        [HttpPost]
        [SwaggerOperation("Tries to authenticate")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthenticateResponse), Description = "Sucessfully authenticated the user.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Incompatible request body")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "User does not exist")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Incorrect password entered")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = await _authService.AuthenticateUser(request);

            if (response == null)
            {
                return NotFound("User does not exist");
            }

            if (response.AuthStatus == "Not Authenticated")
            {
                return Unauthorized("Incorrect password entered");
            }

            return Ok(response);
        }

    }
}
