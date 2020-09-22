namespace ODataSamples.Data.Mappings
{
    using DomainModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.CreatedOn)
                .HasColumnType("DATETIMEOFFSET")
                .IsRequired();
            builder.Property(p => p.LastUpdatedOn)
                .HasColumnType("DATETIMEOFFSET")
                .IsRequired();
            builder.Property(p => p.DeletedOn)
                .HasColumnType("DATETIMEOFFSET");
        }
    }
}