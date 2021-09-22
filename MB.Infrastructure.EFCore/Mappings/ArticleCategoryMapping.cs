using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mappings
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).HasMaxLength(256).IsRequired();
            builder.Property(a => a.CreationDate).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
        }
    }
}
