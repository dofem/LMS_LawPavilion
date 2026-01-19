using LIBRARY_MANAGEMENT_SYSTEM.Data;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Implementation;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Interface;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;
using Microsoft.EntityFrameworkCore;
namespace LIBRARY_MANAGEMENT_SYSTEM.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("Database"));

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration["Database:ConnectionString"]
                ));
        }

        public static void ConfigureApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService,AuthService>();
            builder.Services.AddScoped<IBookService,BookService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<ITokenService,TokenService>();
            builder.Services.AddHttpContextAccessor();
        }
    }

}
