using MVC_web.Models.DB.Models;
using MVC_web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_web.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.DB.Models.OrderInfo postback)
        {
            if (this.ModelState.IsValid)
            {
                using (CartContext db = new CartContext())
                {
                    var currCart = cartFunction.GetCurrCart();
                    //var currCart = (CartItem)System.Web.HttpContext.Current.Session["Cart"];
                    var newOrder = new OrderInfo()
                    {
                        CusName = postback.CusName,
                        CusPhone = postback.CusPhone,
                        TableNo = postback.TableNo
                    };
                    db.OrderInfos.Add(newOrder);
                    db.SaveChanges();
                    foreach (var curr in currCart)
                    {
                        var newOrderItem = new OrderItem()
                        {
                            OID = newOrder.OrderID,
                            iID = curr.iID,
                            iName = curr.iName,
                            iprice = curr.iprice,
                            qty = curr.qty
                        };
                        db.OrderItems.Add(newOrderItem);
                        db.SaveChanges();
                        currCart.ClearCart();
                        return PartialView("_CartPartial");
                    }
                }
                return Content("Checkout Complete");
            }
            return View();
        }

        public ActionResult Orderinfo()
        {
            return View();
        }
    }
}