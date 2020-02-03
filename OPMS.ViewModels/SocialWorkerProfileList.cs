
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class SocialWorkerProfileList:BaseViewModel
    {
        public List<SWorkerProfileVM> SocialProfileVM = new List<SWorkerProfileVM>();
        public List<SWorkerPageVM> SWorkerPageVMs = new List<SWorkerPageVM>();
        public List<SWBannerVM> sWBannerVMs = new List<SWBannerVM>();
        public List<HomeRRViewModel> HomeRRVMs = new List<HomeRRViewModel>();
    }
}
