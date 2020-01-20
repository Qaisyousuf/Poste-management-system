using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Controllers
{
    public class HomeController :BaseController
    {
        public ActionResult Index()
        {
            return View(new PageViewModel());
        }
        [ChildActionOnly]
        public ActionResult PagesMenuPartial()
        {
            var context = _uow.Context;
            var menus = context.Menus;

            foreach (var menu in menus)
            {
                context.Entry(menu).Collection(s => s.SubMenus).Query().Where(x => x.ParentId == menu.Id);
            }
            var menusSub = menus.AsNoTracking().ToList();
            context.Dispose();
            return PartialView(menusSub);
        }
    }
}