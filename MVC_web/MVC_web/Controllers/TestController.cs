using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_web.Controllers
{
    public class TestController : Controller
    {
        public ActionResult GetCart()
        {
            var cart = Models.DB.Models.cartFunction.GetCurrCart();
            cart.AddItem(1);
            return Content(String.Format("Currect Total : {0}", cart.TotalAmount));
        }

        
        // GET: Test
        /*public ActionResult GetCart()
        {
            var cart = Models.DB.Models.cartFunction.GetCurrCart();
            if(cart.cartItems.Count == 0)
            {
                cart.cartItems.Add(
                    new Models.DB.Models.cartItem()
                    {
                        iID = 1,
                        iName = "testItem",
                        qty = 2,
                        iprice = 20
                    });
            }
            else
            {
                cart.cartItems.First().qty += 1;
            }
            return Content(string.Format("Total : {0}", cart.total));
        }*/
    }
}