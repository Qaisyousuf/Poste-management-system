using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

namespace OPMS.Data.FluentAPI
{
    class ContactMapping:EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            Property(f => f.FullName)
                .HasColumnName("Full Namme")
                .IsRequired();
            Property(m => m.MobileNumber)
                .HasColumnName("Mobile Number")
                .IsRequired();
            Property(msg => msg.MessageText)
                .HasColumnName("Message")
                .IsRequired();

        }
    }
}
