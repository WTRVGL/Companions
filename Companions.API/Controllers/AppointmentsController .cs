using AutoMapper;
using Companions.API.DTOs.Appointment;
using Companions.API.DTOs.Buddy;
using Companions.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Companions.API.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Requires JWT")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation("Returns the Appointments from every Buddies associated with the user")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<AppointmentDTO>), Description = "Returns a list of Appointments")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<List<AppointmentDTO>> GetAppointmentsFromUsersBuddies()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = identity.FindFirst("id").Value;

            var appointments = _appointmentService.GetAllAppointmentsByUserId(userId);

            var appointmentsDTO = new List<AppointmentDTO>();
            appointments.ForEach(a =>
            {
                var appointmentDTO = _mapper.Map<AppointmentDTO>(a);
                appointmentsDTO.Add(appointmentDTO);
            });
            return appointmentsDTO;
        }
    }
}
