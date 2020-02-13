using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order(String order)
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            Models.DB.MVCEntities db = new Models.DB.MVCEntities();

            var itemList = (from s in db.Item select s);
            ViewBag.IdSort = String.IsNullOrEmpty(order) ? "idnew" : "";
            ViewBag.TypeSort = order == "Drink" ? "Food" : "Drink";

            switch (order)
            {
                case "idnew":
                    itemList = itemList.OrderByDescending(s => s.itemID);
                    break;
                case "Drink":
                    itemList = itemList.OrderBy(s => s.itemType.Equals("Drink")).ThenBy(s => s.itemID);
                    break;
                case "Food":
                    itemList = itemList.OrderBy(s => s.itemType.Equals("Food")).ThenBy(s => s.itemID);
                    break;
                default:
                    itemList = itemList.OrderBy(s => s.itemID);
                    break;
            }
            return View(itemList.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}