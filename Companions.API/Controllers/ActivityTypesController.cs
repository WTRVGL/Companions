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
    [Route("api/[controller]")]
    [SwaggerTag("Requires JWT")]
    [ApiController]
    public class ActivityTypesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;

        public ActivityTypesController(IMapper mapper, IActivityService activityService)
        {
            _mapper = mapper;
            _activityService = activityService;
        }

        // POST api/<BuddyController>
        [HttpGet]
        [SwaggerOperation("Get all available Activity Types")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ActivityTypeDTO>), Description = "Return all available Activity Types")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "No activities found")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<List<ActivityTypeDTO>> GetAllActivityTypes()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;

            var activityTypes = _activityService.GetActivityTypes();
            var activityTypesDTO = new List<ActivityTypeDTO>();

            if (activityTypes == null) return NotFound("No activities found");

            foreach (var activity in activityTypes)
            {
                var activityTypeDTO = _mapper.Map<ActivityTypeDTO>(activity);
                activityTypesDTO.Add(activityTypeDTO);
            }

            return activityTypesDTO;
        }
    }
}
