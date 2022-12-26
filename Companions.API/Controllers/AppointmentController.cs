using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Companions.API.Controllers
{
    [Route("api/Buddy/{BuddyId}/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAppointmentById(string id)
        {
            return Ok();
        }
    }
}
 