using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

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
