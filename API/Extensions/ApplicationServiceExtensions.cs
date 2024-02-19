using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplicationSerices(this IServiceCollection services, IConfiguration config)
  {
    services.AddDbContext<DataContext>(opt=> {
    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
   });
    services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    

    

    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<IUserRepository, UserRepository>(); //Pour le rendre injectable dans notre UserController
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    return services;
  }
}
