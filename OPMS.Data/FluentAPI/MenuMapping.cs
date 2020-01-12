using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

namespace OPMS.Data.FluentAPI
{
    public class MenuMapping:EntityTypeConfiguration<Menu>
    {
        public MenuMapping()
        {
            Property(m => m.Title)
                .HasColumnName("Menu Title");
        }
    }
}
