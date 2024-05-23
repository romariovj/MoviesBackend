using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using movies.Domain.Repositories;
using movies.Infrastructure.Mappings;
using movies.Infrastructure.Persistences;
using movies.Infrastructure.Persistences.Contexts;

namespace movies.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this  IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddTransient<IMovieRepository, MovieRepository>();

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }
    }
}
