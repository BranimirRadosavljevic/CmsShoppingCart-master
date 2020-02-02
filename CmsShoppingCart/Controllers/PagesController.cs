using CmsShoppingCart.Models.Data;
using CmsShoppingCart.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsShoppingCart.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index(string page = "")
        {
            if (page == "")
                page = "home";

            PageVM model;
            PageDTO dto;

            using (Db db = new Db())
            {
                if (!db.Pages.Any(m => m.Slug == page))
                {
                    return RedirectToAction("Index", new { page = "" });
                }
            }

            using (Db db = new Db())
            {
                dto = db.Pages.Where(m => m.Slug == page).FirstOrDefault();
            }

            ViewBag.PageTitle = dto.Title;
            if (dto.HasSidebar == true)
            {
                ViewBag.Sidebar = "Yes";
            }
            else
            {
                ViewBag.SideBar = "No";
            }

            model = new PageVM(dto);

            return View(model);
        }

        public ActionResult PagesMenuPartial()
        {
            List<PageVM> pageVMList;

            using (Db db = new Db())
            {
                pageVMList = db.Pages.ToArray()
                                    .OrderBy(m => m.Sorting)
                                    .Where(m => m.Slug != "home")
                                    .Select(m => new PageVM(m))
                                    .ToList();
            }

            return PartialView(pageVMList);
        }

        public ActionResult SidebarPartial()
        {
            SidebarVM model;
            using (Db db = new Db())
            {
                SidebarDTO dto = db.Sidebar.Find(1);
                model = new SidebarVM(dto);
            }

            return PartialView(model);
        }
    }
}