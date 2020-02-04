using CmsShoppingCart.Models.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsShoppingCart.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CartPartial()
        {
            CartVM model = new CartVM();
            int qty = 0;
            decimal price = 0m;

            if (Session["cart"] != null)
            {
                var list = (List<CartVM>)Session["cart"];
                foreach (var item in list)
                {
                    qty += item.Quantity;
                    price += item.Total;
                }
            }
            else
            {
                model.Quantity = 0;
                model.Price = 0m;
            }

            return PartialView(model);
        }
    }
}