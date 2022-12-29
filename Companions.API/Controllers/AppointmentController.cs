﻿using Companions.API.DTOs.Appointment;
using Companions.API.Services;
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

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
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
    }
}