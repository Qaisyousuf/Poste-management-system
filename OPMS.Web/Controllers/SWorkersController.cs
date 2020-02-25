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
    public class SWorkersController : BaseController
    {
        
        [Route("SocialWokers")]
        public ActionResult Index()
        {
            var SWPagrFromdb = _uow.SWorkerPageRepository.GetAll();
            var SWbannerFromdb = _uow.SWBaneerRepository.GetAll();

            List<SWorkerPageVM> pageviewmodel = new List<SWorkerPageVM>();

            List<SWBannerVM> bannerviewmodel = new List<SWBannerVM>();


            foreach (var item in SWPagrFromdb)
            {
                pageviewmodel.Add(new SWorkerPageVM
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText,
                    SubContent=item.SubContent,
                    GoogleMapAPIUrl=item.GoogleMapAPIUrl,
                    IsSWorkertMetaDataOn=item.IsSWorkertMetaDataOn,
                    MetaKeywords=item.MetaKeywordse,
                    MetaDescritpion=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    BannerId=item.BannerId,
                    SWbanners=item.SWbanners,
                });
            }

            foreach (var item in SWbannerFromdb)
            {
                bannerviewmodel.Add(new SWBannerVM
                {
                    Id=item.Id,
                    BTitle=item.BTitle,
                    BSubTitle=item.BSubTitle,
                    BContent=item.BContent,
                    BImage=item.BImage,
                    BButton=item.BButton,
                    BButtonUrl=item.BButtonUrl,
                });
            }

            SWorkerMultiVM GetAllData = new SWorkerMultiVM
            {
                SWorkerPageVMs=pageviewmodel,
                sWBannerVMs=bannerviewmodel
            };

            return View(GetAllData);
        }

        public ActionResult SocialProfile()
        {
            var SWorkerFromdb = _uow.SocialProfileRepository.GetAll();

            List<SWorkerProfileVM> viewmodel = new List<SWorkerProfileVM>();

            foreach (var item in SWorkerFromdb)
            {
                viewmodel.Add(new SWorkerProfileVM
                {
                    Id=item.Id,
                    ImageUrl=item.ImageUrl,
                    Title=item.Title,
                    FullName=item.FullName,
                    JobTitle=item.JobTitle,
                    Content=item.Content,
                });
            }

            SocialWorkerProfileList Data = new SocialWorkerProfileList
            {
                SocialProfileVM = viewmodel,
            };
            //SWorkerProfileVM viewmdole = new SWorkerProfileVM
            //{
            //    Id=profile.Id,
            //    Title=profile.Title,
            //    FullName=profile.FullName,
            //    JobTitle=profile.JobTitle,
            //    Content=profile.Content,
            //};
         
            
            return PartialView(Data);

        }
    }
}