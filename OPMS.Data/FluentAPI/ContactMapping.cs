using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    class ContactMapping:EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            Property(f => f.FullName)
                .IsRequired();
            Property(m => m.MobileNumber)
                .IsRequired();
            Property(msg => msg.MessageText)
                .IsRequired();

        }
    }
}
