using AutoMapper;
using Companions.API.DTOs.Appointment;
using Companions.API.Services;
using Companions.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Companions.API.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Requires JWT")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(string id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<AppointmentDTO> CreateAppointment(CreateAppointmentDTO createAppointmentDTO)
        {
            return new AppointmentDTO();
        }

        [HttpPut]
        [SwaggerOperation("Update an appointment")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool), Description = "Appointment updated")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Appointment does not exist")]
        [Authorize]
        public  ActionResult<UpdateAppointmentDTO> UpdateAppointment(UpdateAppointmentDTO updateAppointmentDTO)
        {
            var appointment = _appointmentService.GetAppointentById(updateAppointmentDTO.Id);
            if (appointment == null) return NotFound("Appointment does not exist.");

            var updateAppointment = _mapper.Map<Appointment>(updateAppointmentDTO);
            var updatedAppointment = _appointmentService.UpdateAppointment(updateAppointment);

            var updatedAppointmentDTO = _mapper.Map<UpdateAppointmentDTO>(updatedAppointment);


            return updatedAppointmentDTO;
        }



        [HttpDelete("{id}")]
        [SwaggerOperation("Delete an appointment")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool), Description = "Appointment deleted")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Appointment does not exist")]
        [Authorize]
        public ActionResult<bool> DeleteAppointment(string id)
        {
            var appointment = _appointmentService.GetAppointentById(id);
            if (appointment == null) return NotFound("Appointment does not exist");

            var deleted = _appointmentService.DeleteAppointment(id);
            if (!deleted) return false;

            return Ok(deleted);

        }
    }
}
