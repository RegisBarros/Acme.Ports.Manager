using Acme.Ports.Manager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acme.Ports.Manager.Infrastructure.Data.Mappings
{
    public class PortMap : IEntityTypeConfiguration<Port>
    {
        public void Configure(EntityTypeBuilder<Port> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.HasMany(p => p.DockedShips)
                .WithOne()
                .HasForeignKey("PortId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}