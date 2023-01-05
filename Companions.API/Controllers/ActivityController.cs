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
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;

        public ActivityController(IMapper mapper, IActivityService activityService)
        {
            _mapper = mapper;
            _activityService = activityService;
        }

        // POST api/<BuddyController>
        [HttpPost]
        [SwaggerOperation("Create a new Activity for a Buddy")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ActivityDTO), Description = "Returns the created Activity")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<ActivityDTO> CreateActivity(CreateActivityDTO createActivityDTO, string buddyId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;

            //Map from DTO to Domain model
            var activity = _mapper.Map<Activity>(createActivityDTO);

            var createdActivity = _activityService.CreateActivity(activity);
            //Map from Domain model to return DTO model
            var createdActivityDTO = _mapper.Map<ActivityDTO>(createdActivity);
            return createdActivityDTO;
        }
    }
}
