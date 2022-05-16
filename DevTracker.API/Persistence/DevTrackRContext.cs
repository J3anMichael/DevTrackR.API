using DevTracker.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTracker.API.Persistence
{
    // Vai basicamente funcionar como um banco de dados em memória 
    public class DevTrackRContext : DbContext
    {
        public DevTrackRContext(DbContextOptions<DevTrackRContext> options) : base(options)
        {
        }

        public DbSet<Package> Packages{ get; set; }
        public DbSet<PackageUpdate> PackageUpdates { get; set; }


        // Configuração entre Package e packageUpdate
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.Updates)
                .WithOne()
                .HasForeignKey(pu => pu.PackageId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PackageUpdate>(e =>
            {
                e.HasKey(p =>p.Id);
            });
        }

    }
}
