using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
     public class ContactMultiVM:BaseViewModel
    {
        public List<ContactPageViewModel> ContactPageViewModel = new List<ContactPageViewModel>();
        public List<ContactDetailsVM> ContactDetailsViewModel = new List<ContactDetailsVM>();
        public List<ContactInfoVM> ContactInfoViewModel = new List<ContactInfoVM>();
    }
}
