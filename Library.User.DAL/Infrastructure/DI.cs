using Library.User.DAL.DataServices;
using Library.User.DAL.Repository;
using Library.User.DAL.UsersDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.User.DAL.Infrastructure
{
    public static class DI
    {
        public static void RegisterUserDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<UserDBContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("UserDBConnection"), b => b.MigrationsAssembly("Library.User.DAL"));
            });

            services.AddScoped<IUserRepository, PGRepository>();
            services.AddScoped<IUserDataService, UserDataService>();
        }
    }
}
