using System.Collections.Generic;

namespace OPMS.ViewModels
{
    public class AboutMultiViewModel:BaseViewModel
    {
        public List<AboutPageViewModel> AboutPageViewModels { get; set; }
        public List<AboutSectionViewModel> AboutSectionViewModels { get; set; }
        public List<AboutShortSectionVM> AboutShortSectionViewModels { get; set; }

        public List<NewsInfoVM> NewsInfoViewModel { get; set; }
        public List<NewsBannerVM> NewsBannerViewModel { get; set; }

        public List<MainPostSystemVM> MainPostViewmodels { get; set; }
    }
}
