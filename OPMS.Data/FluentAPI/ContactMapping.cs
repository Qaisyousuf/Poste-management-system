using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

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
