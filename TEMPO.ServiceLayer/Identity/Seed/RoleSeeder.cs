using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPO.ServiceLayer.Identity.Seed;

public class RoleSeeder
{
  public static async Task SeedAsync(IServiceProvider services)
  {
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = ["Admin", "User", "Manager"];

    foreach (var role in roles)
    {
      if (!await roleManager.RoleExistsAsync(role))
      {
        await roleManager.CreateAsync(new IdentityRole(role));
      }
    }
  }
}
