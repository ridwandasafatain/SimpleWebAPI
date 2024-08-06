using Microsoft.EntityFrameworkCore;
using Web.Infrastructure;
using Web.Service;

namespace WebApi
{
    public static class ServiceInjection
    {
        public static void AddApplicationConfiguration(this IServiceCollection services, WebApplicationBuilder applicationBuilder)
        {
            const int commandTimeoutInSeconds = 600;

            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(applicationBuilder.Configuration.GetConnectionString("DbConnection"), t => t.CommandTimeout(commandTimeoutInSeconds)));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
