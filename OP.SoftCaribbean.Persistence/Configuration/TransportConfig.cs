using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.Newshore.Domain.Entities;

namespace OP.Newshore.Persistence.Configuration
{
    public class TransportConfig : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.Property(e => e.FlightCarrier)
                .HasMaxLength(2)
                .IsUnicode()
                .HasColumnType("varchar");

            builder.Property(e => e.FlightNumber)
                .HasMaxLength(4)
                .HasColumnType("varchar");
        }
    }
}
