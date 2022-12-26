using AutoMapper;
using Companions.API.DTOs;
using Companions.API.Models;
using Companions.API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Companions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config, IUserService userService, IMapper mapper)
        {
            _httpClient = new HttpClient();
            var apiBaseURL = config.GetValue<string>("CompanionsAuthenticationServiceURL");
            _httpClient.BaseAddress = new Uri(apiBaseURL);
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("GetUserById/{id}")]
        [SwaggerOperation("Retrieves a user by submitting an id")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDTO), Description = "Returns the user")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Incompatible request body")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        public ActionResult<UserDTO> GetUserById(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound("User not found");
            return _mapper.Map<UserDTO>(user);
        }

        [HttpGet("GetUserByUserName/{username}")]
        [SwaggerOperation("Retrieves a user by submitting a username")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDTO), Description = "Returns the user")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Incompatible request body")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        public ActionResult<UserDTO> GetUserByUserName(string username)
        {
            var user = _userService.GetUserByUserName(username) as Domain.User; ;
            if (user == null) return NotFound("User not found");
            return _mapper.Map<UserDTO>(user);
        }

        // POST api/<UserController>
        [HttpPost(nameof(CreateUser))]
        [SwaggerOperation("Creates a new user", "Makes usage of the Companions Authentication Service")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDTO), Description = "Returns the newly created user")]
        [SwaggerResponse(StatusCodes.Status302Found, Description = "User already exists")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Incompatible request body")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        public async Task<ActionResult<UserDTO>> CreateUser(CreateUser createUser)
        {
            //Get user by Id
            var userExists = _userService.GetUserByUserName(createUser.UserName) != null;
            //If user exists return error
            if (userExists) return new StatusCodeResult(302);

            var user = await _userService.AddUser(createUser);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
