using Library.BLL.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.BLL.Infrastructure
{
    public static class DI
    {
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IBookRentService, BookRentService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
