using AutoMapper;
using Companions.API.DTOs;
using Companions.API.DTOs.Appointment;
using Companions.API.DTOs.Buddy;
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
        [HttpPost]
        [SwaggerOperation("Creates a barebones Buddy associated with the user")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BuddyDTO), Description = "Returns a the newly created Buddy")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<BuddyDTO> CreateBuddy(CreateBuddyDTO createBuddyDTO)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;

            //Map from DTO to Domain model
            var buddy = _mapper.Map<Buddy>(createBuddyDTO);

            buddy.UserId = userId;

            var createdBuddy = _buddyService.AddBuddy(buddy);
            //Map from Domain model to return DTO model
            var createdBuddyDTO = _mapper.Map<BuddyDTO>(createdBuddy);
            return createdBuddyDTO;
        }

        [HttpPut]
        [SwaggerOperation("Update an exiting Buddy")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BuddyDTO), Description = "Returns the updated Buddy")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Buddy does not exist")]
        [Authorize]
        public ActionResult<BuddyDTO> UpdateBuddy(UpdateBuddyDTO updateBuddyDTO)
        {
            var buddy = _buddyService.GetBuddyById(updateBuddyDTO.Id);
            if (buddy == null) return NotFound("Buddy does not exist.");

            var updateBuddy = _mapper.Map<Buddy>(updateBuddyDTO);
            var updatedBuddy = _buddyService.UpdateBuddy(updateBuddy);
            
            var updatedBuddyDTO = _mapper.Map<BuddyDTO>(updatedBuddy);

            return updatedBuddyDTO;
        }


        [HttpDelete("{id}")]
        [SwaggerOperation("Deletes a Buddy")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool), Description = "Delete a Buddy")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Buddy does not exist")]
        [Authorize]
        public ActionResult<bool> DeleteBuddy(string id)
        {
            var appointment = _buddyService.GetBuddyById(id);
            if (appointment == null) return NotFound("Buddy does not exist");

            var deleted = _buddyService.DeleteBuddy(id);
            if (!deleted) return false;

            return Ok(deleted);
        }
    }
}
