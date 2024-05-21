using Application.Dto;
using Application.Tools;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(UserDto dto)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, dto.Id)
            };

            if (!string.IsNullOrWhiteSpace(dto.Name))
                claims.Add(new Claim("Name", dto.Name));

            if (!string.IsNullOrWhiteSpace(dto.Email))
                claims.Add(new Claim("Email", dto.Email));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();

            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }

    }
}
