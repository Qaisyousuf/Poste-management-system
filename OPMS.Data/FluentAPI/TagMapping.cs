using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    public class TagMapping:EntityTypeConfiguration<Tag>
    {
        public TagMapping()
        {
            Property(t => t.Name)
                .HasColumnName("Tag Name")
                .IsRequired();
        }
    }
}
