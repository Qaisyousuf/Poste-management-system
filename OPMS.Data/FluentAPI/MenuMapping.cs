using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    public class MenuMapping:EntityTypeConfiguration<Menu>
    {
        public MenuMapping()
        {
            Property(m => m.Title)
                .IsRequired();
        }
    }
}
