using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_web.Controllers
{
    public class CartController : Controller
    {
        // GET: cart
        public ActionResult getCart()
        {
            return PartialView("_CartPartial");
        }

        public ActionResult AddToCart(int id)
        {
            var currCart = Models.DB.Models.cartFunction.GetCurrCart();
            currCart.AddItem(id);
            return PartialView("_CartPartial");
            
        }
    }
}