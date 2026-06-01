using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TEMPO.Data.Entities;
using TEMPO.Service.Interfaces;

namespace TEMPO.Service.Services;

public class JwtTokenService(IConfiguration configuration) : ITokenService
{
  private readonly IConfiguration _configuration = configuration;
  public async Task<string> CreateToken(AppUser user, IList<string> roles)
  {
    var claims = new List<Claim>
    {
      new (ClaimTypes.NameIdentifier, user.Id),
      new (ClaimTypes.Email, user.Email!),
    };

    claims.AddRange(
      roles.Select(role => new Claim(ClaimTypes.Role, role))
    );

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var expiresInHours = int.Parse(_configuration["Jwt:ExpiresInHours"]!);

    var token = new JwtSecurityToken(
      issuer: _configuration["Jwt:Issuer"],
      audience: _configuration["Jwt:Audience"],
      claims: claims,
      expires: DateTime.UtcNow.AddHours(expiresInHours),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}