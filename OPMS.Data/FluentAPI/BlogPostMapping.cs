using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

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
