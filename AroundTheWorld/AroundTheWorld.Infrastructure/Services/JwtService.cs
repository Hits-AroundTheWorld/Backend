using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Services
{
    public class JwtService : IJwtService
    {

        private readonly TokenProps _tokenInfo;

        public JwtService(TokenProps tokenInfo)
        {
            _tokenInfo = tokenInfo;

        }

        public string CreateJWTToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_tokenInfo.AccessTokenExpiration.TotalMinutes),
                SigningCredentials = new SigningCredentials(_tokenInfo.TokenKey, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                })
                //ISSUER, AUDIENCE
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
