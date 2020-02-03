using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class SWorkerMultiVM:BaseViewModel
    {
        public List<SWorkerPageVM> SWorkerPageVMs = new List<SWorkerPageVM>();
        public List<SWBannerVM> sWBannerVMs = new List<SWBannerVM>();
    }
}
