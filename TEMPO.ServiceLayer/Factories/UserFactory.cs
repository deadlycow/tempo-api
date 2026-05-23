using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Factories;

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
  public static UserModel ToModel(AppUser entity)
  {
    ArgumentNullException.ThrowIfNull(entity);

    return new()
    {
      UserName = entity.UserName,
      Email = entity.Email,
      PhoneNumber = entity.PhoneNumber
    };
  }
  public static IEnumerable<UserModel> ToModelList(IEnumerable<AppUser> entities) => [.. entities.Select(ToModel)];
}