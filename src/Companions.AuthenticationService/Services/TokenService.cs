using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;

namespace Companions.AuthenticationService.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPasswordService _hashPasswordService;
        private readonly IConfiguration _config;

        private readonly JWTConfiguration _jwtConfig;

        public TokenService(IUserRepository userRepository, IHashPasswordService hashPasswordService, IConfiguration config)
        {
            _userRepository = userRepository;
            _hashPasswordService = hashPasswordService;
            _config = config;

            _jwtConfig = _config.GetSection("JWT").Get<JWTConfiguration>();
        }

        /// <summary>
        /// Generate a JWT with claims from a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// A Base64 encoded JWT with username, id and role claims.
        /// </returns>
        public string GetJwtSecurityToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim("role", user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.ValidIssuer,
                audience: _jwtConfig.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Convert.FromBase64String(_jwtConfig.Secret)), SecurityAlgorithms.HmacSha256));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        /// <summary>
        /// Decodes a JWT string
        /// </summary>
        /// <param name="token"></param>
        /// <returns>JwtSecurityToken object</returns>
        public JwtSecurityToken DecodeJwtSecurityToken(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token);
        }

        /// <summary>
        /// Extracts the user id from a JwtSecurityToken object
        /// </summary>
        /// <param name="securityToken"></param>
        /// <returns>user id</returns>
        public string ExtractIdFromJwtSecurityToken(JwtSecurityToken securityToken)
        {
            var idClaim = securityToken.Claims.FirstOrDefault(claim => claim.Type == "id");
            return idClaim.Value;
        }
    }
}