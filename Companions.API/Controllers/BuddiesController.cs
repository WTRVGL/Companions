using AutoMapper;
using Companions.API.DTOs;
using Companions.API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Companions.API.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("JWT in HTTPOnly Cookie is required to turn the user's Buddiess")]
    [ApiController]
    public class BuddiesController : ControllerBase
    {
        private readonly IBuddyService _buddyService;
        private readonly IMapper _mapper;

        /// <summary>
        /// yo
        /// </summary>
        /// <param name="buddyService"></param>
        /// <param name="mapper"></param>
        public BuddiesController(IBuddyService buddyService, IMapper mapper)
        {
            _buddyService = buddyService;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAllBuddies))]
        [SwaggerOperation("Returns all buddies associated with the current User (HTTP Only Cookie JWT Claim)")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<BuddyDTO>), Description = "Returns list of buddies")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        public ActionResult<List<BuddyDTO>> GetAllBuddies()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId; 
            userId = identity.FindFirst("id").Value;

            if (identity == null) return Unauthorized("No user ID found");

            IEnumerable<Claim> claims = identity.Claims;

            //Fetch buddies by userID when auth service supports
            //var buddies = _buddyService.GetAllBuddiesByUserId(userId);

            var buddies = _buddyService.GetAllBuddies();

            if (buddies == null) return NotFound();
            var buddiesDTO = _mapper.Map<List<BuddyDTO>>(buddies);
            return buddiesDTO;
        }

    }
}
