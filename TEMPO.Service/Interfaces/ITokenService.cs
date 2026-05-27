using TEMPO.Data.Entities;

namespace TEMPO.Service.Interfaces;

public interface ITokenService
{
  Task<string> CreateToken(AppUser user, IList<string> roles);
}