using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Factories;

public class UserFactory
{
  public static TempoUser ToEntity(CreateUserCommand command)
  {
    ArgumentNullException.ThrowIfNull(command);

    return new TempoUser
    {
      UserName = command.UserName,
      Email = command.Email
    };
  }
  public static UserModel ToModel(TempoUser entity)
  {
    ArgumentNullException.ThrowIfNull(entity);

    return new UserModel
    {
      UserName = entity.UserName,
      Email = entity.Email
    };
  }
}