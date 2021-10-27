using System.Linq;
using Acme.Ports.Manager.Core.Models;
using Acme.Ports.Manager.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Acme.Ports.Manager.Infrastructure.Data
{
    public sealed class PortsManagerContext : DbContext
    {
        public PortsManagerContext(DbContextOptions<PortsManagerContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Port> Ports { get; set; }
        public DbSet<Ship> Ships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) 
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new PortMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}