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
                if (!db.Pages.Any(m => m.Slug.Equals(page)))
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
    }
}