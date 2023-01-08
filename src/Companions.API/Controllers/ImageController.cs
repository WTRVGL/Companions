using AutoMapper;
using Companions.API.DTOs;
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
    public class ImageController : ControllerBase
    {
        private readonly IBuddyService _buddyService;
        private readonly IMapper _mapper;

        public ImageController(IMapper mapper, IBuddyService buddyService)
        {
            _mapper = mapper;
            _buddyService = buddyService;
        }


        [HttpPost]
        [SwaggerOperation("Adds an Image for a Buddy")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ImageDTO), Description = "Returns the added Image")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Buddy Not Found")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<ImageDTO> AddImage(ImageDTO imageDTO, string buddyId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;

            var buddy = _buddyService.GetBuddyById(buddyId);
            if (buddy == null) return NotFound("Buddy does not exist");

            var image = _mapper.Map<Image>(imageDTO);

            buddy.Images.Add(image);

            var updatedBuddy = _buddyService.UpdateBuddy(buddy);

            var createdImage = updatedBuddy.Images.FirstOrDefault(i => i.Id == image.Id);

            return imageDTO;
        }
    }
}
