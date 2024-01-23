using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Teamsec_Case.Domain.models;

namespace Teamsec_Case.Persistence.contexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=Deneme;User=sa;Password=1234");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }
    }
}
