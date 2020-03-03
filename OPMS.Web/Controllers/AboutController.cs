using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Controllers
{

    [ExceptionFilter]
    public class AboutController : BaseController
    {

        [Route("AboutUs")]
        [ExceptionFilter]
        public ActionResult Index()
        {
            //int number = int.Parse("hello");
            var aboutPageFromDb = _uow.AboutPageRepository.GetAll();

            var aboutSection = _uow.AboutSectionRepository.GetAll();

            var aboutshortSection = _uow.AboutShortSectionRepository.GetAll();


            List<AboutPageViewModel> AboutPageviewmodel = new List<AboutPageViewModel>();

            List<AboutSectionViewModel> aboutSectionviewmodel = new List<AboutSectionViewModel>();

            List<AboutShortSectionVM> aboutShortSectionviewmodel = new List<AboutShortSectionVM>();


            foreach (var item in aboutPageFromDb)
            {
                AboutPageviewmodel.Add(new AboutPageViewModel
                {
                    Id=item.Id,
                    Slug=item.Slug,
                    MainTitle=item.MainTitle,
                    BannerImage=item.BannerImage,
                    SubTitle=item.SubTitle,
                    ButtonUrl=item.ButtonUrl,
                    Content=item.Content,
                    IsMetaDataOn=item.IsAboutMetaDataOn,
                    MetaKeywords=item.MetaDescription,
                    MetaDescritpion=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    SectoinId=item.SectoinId,
                    AboutSection=item.AboutSection,
                    ShortSectionId=item.ShortSectionId,
                    AboutShortSection=item.AboutShortSection,
                });
            }

            foreach (var item in aboutSection)
            {
                aboutSectionviewmodel.Add(new AboutSectionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ButtonUrl=item.ButtonUrl,
                    UrlImages=item.UrlImages,
                    PublishDateTime=item.PublishDateTime
                });
            }

            foreach (var item in aboutshortSection)
            {
                aboutShortSectionviewmodel.Add(new AboutShortSectionVM
                {
                    Id=item.Id,
                    Title=item.Title,
                    SubTitle=item.SubTitle,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    SubContent=item.SubContent,
                    PublishDateTime=item.PublishDateTime
                });
            }


            AboutMultiViewModel allData = new AboutMultiViewModel
            {
               AboutPageViewModels=AboutPageviewmodel,
               AboutSectionViewModels=aboutSectionviewmodel,
               AboutShortSectionViewModels=aboutShortSectionviewmodel
            };

            return View(allData);
        }
    }
}