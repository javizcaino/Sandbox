namespace ODataSamples.Data.Mappings
{
    using DomainModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ProductRatingMapping : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            // Table Name
            builder.ToTable("ProductRatings", "dbo");

            // Primary Key
            builder.HasKey(t => t.Id);

            MapFields(builder);
            MapRelationships(builder);
        }

        /// <summary>
        /// Maps the fields.
        /// </summary>
        private void MapFields(EntityTypeBuilder<ProductRating> builder)
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(p => p.ProductId)
                .IsRequired();
            builder.Property(p => p.Rating)
                .IsRequired();
            builder.Property(p => p.RatedOn)
                .IsRequired();
            builder.Property(p => p.Username)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.Comments)
                .HasMaxLength(500)
                .IsRequired(false);
        }

        /// <summary>
        /// Maps the relationships.
        /// </summary>
        private void MapRelationships(EntityTypeBuilder<ProductRating> builder)
        {
            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductRatings)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}