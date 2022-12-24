﻿using AutoMapper;
using Companions.API.DTOs;
using Companions.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Companions.API.Controllers
{
    [Route("api/[controller]")]
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

        // GET: api/<BuddyController>
        [HttpGet]
        public ActionResult<List<BuddyDTO>> GetAllBuddies()
        {
            var buddies = _buddyService.GetAllBuddies();
            if (buddies == null) return NotFound();
            var buddiesDTO = _mapper.Map<List<BuddyDTO>>(buddies);
            return buddiesDTO;
        }

        // GET api/<BuddyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BuddyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
