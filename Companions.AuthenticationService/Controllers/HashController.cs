using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Companions.AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        private readonly IHashPasswordService _hashService;

        public HashController(IHashPasswordService hashService)
        {
            _hashService = hashService;
        }
        
        [HttpPost(nameof(GenerateHashKeys))]
        [SwaggerOperation("Generates a PBKDF2 Hash and Salt pair from a password")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PBKDF2Keys), Description = "Password succesfully hashed")]
        public ActionResult<PBKDF2Keys> GenerateHashKeys(HashRequest request)
        {
            var keys = _hashService.GenerateHashAndSalt(request.Password) as PBKDF2Keys;
            return keys;
        }
    }
}
