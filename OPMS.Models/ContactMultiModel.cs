using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class ContactMultiModel
    {
        public List<ContactMainPage> ContactPage = new List<ContactMainPage>();
        public List<ContactDetails> CotnactDetails = new List<ContactDetails>();
        public List<ContactInfo> ContactInfo = new List<ContactInfo>();
    }
}
