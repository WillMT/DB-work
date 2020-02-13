using MVC_web.Models.DB.Models;
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
            var item = (from s in db.Item select s);
            var drink = (from s in db.Item where s.itemType == "Drink" select s);
            var Food = (from s in db.Item where s.itemType == "Food" select s);

            var model = new itemViewModel()
            {
                DrinkList = drink,
                FoodList = Food,
                itemList = item
            };

            return View(model);
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