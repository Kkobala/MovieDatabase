using Microsoft.EntityFrameworkCore;
using MovieDatabase.App.Db.Entities;
using MovieDatabase.App.Db.Mapping;

namespace MovieDatabase.App.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MovieEntity> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieMap());

            base.OnModelCreating(builder);
        }
    }
}
