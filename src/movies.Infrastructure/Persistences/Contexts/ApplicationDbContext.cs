using Microsoft.EntityFrameworkCore;
using movies.Infrastructure.Persistences.DataEntities;
using System.Reflection;

namespace movies.Infrastructure.Persistences.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<MovieEntity> Movies { get; set; }
    }
}
