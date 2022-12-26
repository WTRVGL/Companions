using AutoMapper;
using Companions.API.DTOs;
using Companions.API.Services;
using Companions.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Companions.API.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Requires JWT")]
    [ApiController]
    public class BuddyController : ControllerBase
    {
        private readonly IBuddyService _buddyService;
        private readonly IMapper _mapper;

        public BuddyController(IBuddyService buddyService, IMapper mapper)
        {
            _buddyService = buddyService;
            _mapper = mapper;
        }

        // POST api/<BuddyController>
        [HttpPost(nameof(CreateBuddy))]
        [SwaggerOperation("Creates a barebones Buddy associated with the user")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BuddyDTO), Description = "Returns a the newly created Buddy")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<BuddyDTO> CreateBuddy(CreateBuddyDTO createBuddyDTO)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;
            createBuddyDTO.UserId = userId;

            //Map from DTO to Domain model
            var buddy = _mapper.Map<Buddy>(createBuddyDTO);
            var createdBuddy = _buddyService.AddBuddy(buddy);
            //Map from Domain model to return DTO model
            var createdBuddyDTO = _mapper.Map<BuddyDTO>(createdBuddy);
            return createdBuddyDTO;
        }

        [HttpPut(nameof(UpdateBuddy))]
        [SwaggerOperation("Update an exiting Buddy")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BuddyDTO), Description = "Returns the updated Buddy")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Buddy does not exist")]
        [Authorize]
        public ActionResult<BuddyDTO> UpdateBuddy([FromBody] BuddyDTO buddyDTO)
        {
            return new BuddyDTO();
        }

 
        [HttpDelete(nameof(DeleteBuddy))]
        [SwaggerOperation("Deletes a Buddy")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool), Description = "Delete a Buddy")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Buddy does not exist")]
        [Authorize]
        public ActionResult<bool> DeleteBuddy(string id)
        {
            return true;
        }
    }
}
