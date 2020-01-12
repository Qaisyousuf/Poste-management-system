using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    public class BlogPostMapping:EntityTypeConfiguration<BlogPost>
    {
        public BlogPostMapping()
        {
            HasMany(t => t.Tags)
                .WithMany(b => b.BlogPosts)
                .Map(tb =>
                {
                    tb.MapLeftKey("BlogPostId");
                    tb.MapRightKey("TagId");
                    tb.ToTable("BlogPostTag");
                });
            
        }
    }
}
