using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_web.Controllers
{
    public class itemController : Controller
    {
        // GET: item
        public ActionResult Index()
        {
            List<Models.DB.Item> itemList = new List<Models.DB.Item>();
            using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
            {
                itemList = (from s in db.Item select s).ToList();
                return View(itemList);

            }
        }
    }
}