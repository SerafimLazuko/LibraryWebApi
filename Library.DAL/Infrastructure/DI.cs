using Library.DAL.DataServices;
using Library.DAL.DBContext;
using Library.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.DAL.Infrastructure
{
    public static class DI
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<BookRentDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Library.DAL"));
            });

            services.AddScoped<IBookRentRepository, MSSQLBookRentRepository>();
            services.AddScoped<IBookRentDataService, BookRentDataService>();
        }
    }
}