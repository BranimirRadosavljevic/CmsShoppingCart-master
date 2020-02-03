using CmsShoppingCart.Models.Data;
using CmsShoppingCart.Models.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pages");
        }

        public ActionResult CategoryMenuPartial()
        {
            List<CategoryVM> categoryVMList;
            using (Db db = new Db())
            {
                categoryVMList = db.Categories.ToArray()
                                                .OrderBy(m => m.Sorting)
                                                .Select(m => new CategoryVM(m))
                                                .ToList();
            }

            return PartialView(categoryVMList);
        }

        public ActionResult Category(string name)
        {
            List<ProductVM> productVMList;

            using (Db db = new Db())
            {
                CategoryDTO categoryDTO = db.Categories.Where(m => m.Slug == name).FirstOrDefault();
                int catId = categoryDTO.Id;

                productVMList = db.Products
                                    .ToArray()
                                    .Where(m => m.CategoryId == catId)
                                    .Select(m => new ProductVM(m))
                                    .ToList();

                //var productCat = db.Products.Where(m => m.CategoryId == catId).FirstOrDefault();
                //ViewBag.CategoryName = productCat.CategoryName;

                var productCat = db.Categories.Find(catId);
                ViewBag.CategoryName = productCat.Name;
            }

            return View(productVMList);
        }

    }
}