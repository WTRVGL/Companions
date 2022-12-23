using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Companions.AuthenticationService.Repositories;
using Companions.AuthenticationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Companions.AuthenticationService.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public JwtMiddleware(RequestDelegate next, ITokenService tokenService, IUserRepository userRepository)
        {
            _next = next;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Cookies["Jwtkoek"];
            
            if (token != null)
            {
                var jwtSecurityToken = _tokenService.DecodeJwtSecurityToken(token);
                var id = _tokenService.ExtractIdFromJwtSecurityToken(jwtSecurityToken);
                // attach user to context on successful jwt validation
                context.Items["User"] = _userRepository.GetUser(id);
            }

            await _next(context);
        }
    }
}
