using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mappings
{
    class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).HasMaxLength(500).IsRequired();
            builder.Property(a => a.ImagePath).IsRequired();
            builder.Property(a => a.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.IsDeleted);
            builder.Property(a => a.CreationDate);
            builder.Property(a => a.CategoryId).IsRequired();

            builder.HasOne<ArticleCategory>(a => a.ArticleCategory)
                .WithMany(ac => ac.Articles).HasForeignKey(a => a.CategoryId);
            
        }
    }
}
