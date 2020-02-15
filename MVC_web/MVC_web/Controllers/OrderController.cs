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
                        TableNo = postback.TableNo,
                        Total = currCart.TotalAmount,
                        OrderStatus = "Payment"
                        
                    };
                    //int currOID = newOrder.OrderID;
                    
                    db.OrderInfos.Add(newOrder);
                    db.SaveChanges();

                    var Order = currCart.ToOrderDetailList(newOrder.OrderID);
                    db.OILs.AddRange(Order);
                    db.SaveChanges();

                    currCart.ClearCart();
                    return RedirectToAction("Info", new { id = newOrder.OrderID });
                    //return PartialView("_CartPartial");
                }
                //return RedirectToAction("Action", new { id = currOID });
            }
            //return RedirectToAction("Action", new { id = currOID });
            return View();
        }

        public ActionResult Info(int id)
        {
            
            CartContext db = new CartContext();
                var OInfoList = (from s in db.OrderInfos where s.OrderID == id select s);
                var OItemList = (from s in db.OILs where s.OID == id select s);
               // var OInfoList = (from s in db.OrderInfos select s);
                //var OItemList = (from s in db.OILs select s);
                
                var model = new OrderViewModel()
                {
                    OrderinfoList = OInfoList,
                    OrderItemList = OItemList
                };
                return View(model);

        }

        [Authorize]
        public ActionResult OrderInfo()
        {

            CartContext db = new CartContext();
            var OInfoList = (from s in db.OrderInfos where s.OrderStatus == "Payment" select s);
            //var OItemList = (from s in db.OILs where s.OID == id select s);
  

            var model = new OrderViewModel()
            {
                OrderinfoList = OInfoList,
                //OrderItemList = OItemList
            };
            return View(model);

        }
        public ActionResult OrderCheck()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            int currID = id;
            CartContext db = new CartContext();
            var OInfoList = (from s in db.OrderInfos where s.OrderID == currID select s);
            var OItemList = (from s in db.OILs where s.OID == currID select s);

            db.OILs.RemoveRange(OItemList.ToList());
            db.OrderInfos.RemoveRange(OInfoList.ToList());
            db.SaveChanges();

            var currCart = cartFunction.GetCurrCart();
            currCart.ClearCart();
            db.SaveChanges();

            return RedirectToAction("Deleted", new { id = currID });
        }

        public ActionResult Deleted(int id)
        {
            CartContext db = new CartContext();
            var OInfoList = (from s in db.OrderInfos where s.OrderID == id select s);
            var OItemList = (from s in db.OILs where s.OID == id select s);
            // var OInfoList = (from s in db.OrderInfos select s);
            //var OItemList = (from s in db.OILs select s);


            var model = new OrderViewModel()
            {
                OrderinfoList = OInfoList,
                OrderItemList = OItemList
            };
            return View(model);

        }
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id)
        {

            CartContext db = new CartContext();
            var OInfoList = (from s in db.OrderInfos where s.OrderID == id select s);
            var OItemList = (from s in db.OILs where s.OID == id select s);
            // var OInfoList = (from s in db.OrderInfos select s);
            //var OItemList = (from s in db.OILs select s);
            int currID = id;
            var currCart = cartFunction.GetCurrCart();
            var Order = currCart.ToOrderDetailList(id);
            db.OILs.AddRange(Order);
            db.SaveChanges();
            currCart.ClearCart();
            var model = new OrderViewModel()
            {
                OrderinfoList = OInfoList,
                OrderItemList = OItemList
            };
            return RedirectToAction("Updated", new { id = currID });
        }

        public ActionResult Updated(int id)
        {
            CartContext db = new CartContext();
            var OInfoList = (from s in db.OrderInfos where s.OrderID == id select s);
            var OItemList = (from s in db.OILs where s.OID == id select s);
            // var OInfoList = (from s in db.OrderInfos select s);
            //var OItemList = (from s in db.OILs select s);


            var model = new OrderViewModel()
            {
                OrderinfoList = OInfoList,
                OrderItemList = OItemList
            };
            return View(model);

        }
    }
}