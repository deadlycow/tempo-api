using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
using TEMPO.Service.Command;

namespace TEMPO.Service.Factories;

public class UserFactory
{
  public static AppUser ToEntity(CreateUserCommand command)
  {
    ArgumentNullException.ThrowIfNull(command);

    return new AppUser
    {
      UserName = command.UserName,
      Email = command.Email,
      PhoneNumber = command.PhoneNumber
    };
  }
  public static UserResponse ToResponse(AppUser entity)
  {
    ArgumentNullException.ThrowIfNull(entity);

    return new()
    {
      UserName = entity.UserName,
      Email = entity.Email,
      PhoneNumber = entity.PhoneNumber
    };
  }
  public static IEnumerable<UserResponse> ToResponseList(IEnumerable<AppUser> entities) => [.. entities.Select(ToResponse)];
}