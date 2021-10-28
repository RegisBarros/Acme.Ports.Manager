using Acme.Ports.Manager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acme.Ports.Manager.Infrastructure.Data.Mappings
{
    public class ShipMap : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.Property(s => s.Id)
                .HasColumnName("Id");

            builder.Property(s => s.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.HasOne(s => s.CurrentPort)
                .WithMany()
                .HasForeignKey("CurrentPortId");
        }
    }
}