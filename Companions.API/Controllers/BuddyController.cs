using AutoMapper;
using Companions.API.DTOs;
using Companions.API.Services;
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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<BuddyDTO>), Description = "Returns a the newly created Buddy")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<BuddyDTO> CreateBuddy(CreateBuddyDTO createBuddyDTO)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;
            createBuddyDTO.UserId = userId;

            //call db
            var buddy = _mapper.Map<BuddyDTO>(createBuddyDTO);
            return new BuddyDTO();
        }

        // PUT api/<BuddyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BuddyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
