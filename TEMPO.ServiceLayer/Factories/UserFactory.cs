using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;

namespace TEMPO.ServiceLayer.Factories;

public class UserFactory
{
  public static TempoUser ToEntity(UserModel userModel)
  {
    ArgumentNullException.ThrowIfNull(userModel);

    return new TempoUser
    {
      UserName = userModel.UserName,
      Email = userModel.Email
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