using AutoMapper;
using Companions.API.DTOs.Activity;
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
    [Route("api/Buddy/{buddyId}/[controller]")]
    [SwaggerTag("Requires JWT")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private readonly IBuddyService _buddyService;
        private readonly IMapper _mapper;

        public WeightController(IMapper mapper, IBuddyService buddyService)
        {
            _mapper = mapper;
            _buddyService = buddyService;
        }

        // POST api/<BuddyController>
        [HttpPost]
        [SwaggerOperation("Create a new BuddyWeight")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BuddyWeightDTO), Description = "Returns the created BuddyWeight")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Not Found")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<BuddyWeightDTO> CreateBuddyWeight(CreateBuddyWeightDTO createBuddyWeightDTO, string buddyId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;

            var buddy = _buddyService.GetBuddyById(buddyId);
            if (buddy == null) return NotFound("Buddy does not exist");

            var buddyWeight = _mapper.Map<BuddyWeight>(createBuddyWeightDTO);

            buddy.BuddyWeights.Add(buddyWeight);

            var updatedBuddy = _buddyService.UpdateBuddy(buddy);

            var createdBuddyWeight = updatedBuddy.BuddyWeights.FirstOrDefault(w => w.Id == buddyWeight.Id);
            var createdBuddyWeightDTO = _mapper.Map<BuddyWeightDTO>(createdBuddyWeight);

            return createdBuddyWeightDTO;
        }
    }
}
