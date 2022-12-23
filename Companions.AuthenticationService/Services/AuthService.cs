﻿using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security;

namespace Companions.AuthenticationService.Services
{
    public class AuthService : IAuthService

    {

    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IHashPasswordService _hashPasswordService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService, IHashPasswordService hashPasswordService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _hashPasswordService = hashPasswordService;
    }


    /// <summary>
    /// Authenticates the user 
    /// </summary>
    /// <returns>null if user does not exist. Empty AuthenticationResul</returns>
    public AuthenticateResponse AuthenticateUser(AuthenticateRequest model)
    {
        var user = _userRepository.GetUserByUserName(model.Username);

            if (user == null) return null;
        

        var authenticated =
            _hashPasswordService.CompareBase64HashValues(model.Password, user.PasswordHash, user.PasswordSalt);

        if (!authenticated)
        {
                return new AuthenticateResponse(null, null, "Not Authenticated");
        }

        var authResult = _tokenService.GetJwtSecurityToken((user));

            
        return new AuthenticateResponse(user, authResult, "Authenticated");

    }

    }
}
