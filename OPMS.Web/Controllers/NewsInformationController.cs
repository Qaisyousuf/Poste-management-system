using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Controllers
{
    public class NewsInformationController : BaseController
    {
        [Route("News")]
        public ActionResult Index()
        {
            var newsInfo = _uow.NewInfoRepository.GetAll();

            List<NewsInfoVM> viewmodel = new List<NewsInfoVM>();

            foreach (var item in newsInfo)
            {
                viewmodel.Add(new NewsInfoVM
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText,
                    SubContent=item.SubContent,
                    PublishDate=item.PublishDate,
                    ImageUrl=item.ImageUrl,
                    GoogleMapAPIUrl=item.GoogleMapAPIUrl,
                    IsMetaDataOn=item.IsNewsInfotMetaDataOn,
                    MetaKeywords=item.MetaKeywordse,
                    MetaDescritpion=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    NewsBannerId=item.NewsBannerId,
                    NewsBanners=item.NewsBanners,
                });
            }

            AboutMultiViewModel NewsInfoData = new AboutMultiViewModel
            {
                NewsInfoViewModel = viewmodel,
             
            };

            return View(NewsInfoData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetNewsBanner()
        {
            var newsBanner = _uow.NewsBannerRepoistory.GetAll();
            List<NewsBannerVM> Bannerviewmodel = new List<NewsBannerVM>();

            foreach (var item in newsBanner)
            {
                Bannerviewmodel.Add(new NewsBannerVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    SubTitle = item.SubTitle,
                    ImageUrl = item.ImageUrl,
                    ButtonText = item.ButtonText,
                    ButtonUrl = item.ButtonUrl,
                    Content = item.Content,
                });
            }
            AboutMultiViewModel NewsBannerData = new AboutMultiViewModel
            {
               
                NewsBannerViewModel = Bannerviewmodel
            };

            return PartialView(NewsBannerData);
        }

    }
}