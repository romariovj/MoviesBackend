using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using movies.Infrastructure.Persistences.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.Infrastructure.Persistences
{
    public class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
