using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Domain.Entities;

namespace RecipeFinder.Infrastructure.Domain.Measurements
{
    public class MeasurementEntityTypeConfiguration : IEntityTypeConfiguration<Measurement>
    {
        internal const string TABLE_MEASUREMENT = "Measurement";
        internal const string TABLE_MEASUREMENT_COL_NAME = "Name";

        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable(TABLE_MEASUREMENT);
            builder.Property(p => p.Name).HasColumnName(TABLE_MEASUREMENT_COL_NAME);
        }
    }
}
