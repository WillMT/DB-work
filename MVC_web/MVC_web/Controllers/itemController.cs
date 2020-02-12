using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_web.Models;

namespace MVC_web.Controllers
{
    public class itemController : Controller
    {
        public ActionResult Index(string order)
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

        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            String drink = "Drink";
            String food = "Food";
            list.Add(new SelectListItem() { Text = drink, Value = drink });
            list.Add(new SelectListItem() { Text = food, Value = food });
            ViewBag.ItemList = list;

            List<SelectListItem> list2 = new List<SelectListItem>();
            String y = "Y";
            String n = "N";
            list2.Add(new SelectListItem() { Text = y, Value = y });
            list2.Add(new SelectListItem() { Text = n, Value = n });
            ViewBag.YNList = list2;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.DB.Item postback)
        {
            if (this.ModelState.IsValid)
            {
                using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
                {           
                        db.Item.Add(postback);
                        db.SaveChanges();
                        TempData["ResultMessage"] = String.Format("item 「{0}」 add successful with image", postback.itemName);
                        return RedirectToAction("Index");
                }
            }
            ViewBag.ResultMessage = "Input error, Please input again!";
            return View(postback);

        }
        public ActionResult Edit(int id)
        {

            using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
            {
                var result = (from s in db.Item where s.itemID == id select s).FirstOrDefault();
                if (result != default(Models.DB.Item))
                {
                    List<SelectListItem> list = new List<SelectListItem>();
                    String drink = "Drink";
                    String food = "Food";
                    list.Add(new SelectListItem() { Text = drink, Value = drink });
                    list.Add(new SelectListItem() { Text = food, Value = food });
                    ViewBag.ItemList = list;

                    List<SelectListItem> list2 = new List<SelectListItem>();
                    String y = "Y";
                    String n = "N";
                    list2.Add(new SelectListItem() { Text = y, Value = y });
                    list2.Add(new SelectListItem() { Text = n, Value = n });
                    ViewBag.YNList = list2;

                    return View(result);

                }
                else
                {
                    TempData["ResultMessage"] = "Searching not found, please choose again";
                    return RedirectToAction("Index");
                }
            }
        }
        [HttpPost]
        public ActionResult Edit(Models.DB.Item postback)
        {
            if (this.ModelState.IsValid)
            {
                using(Models.DB.MVCEntities db = new Models.DB.MVCEntities())
                {
                    var result = (from s in db.Item where s.itemID == postback.itemID select s).FirstOrDefault();
                    result.itemID = postback.itemID;
                    result.itemName = postback.itemName;
                    result.iDesc = postback.iDesc;
                    result.itemType = postback.itemType;
                    result.iStatus = postback.iStatus;
                    result.iPrice = postback.iPrice;
                    result.qty = postback.qty;
                    db.SaveChanges();
                    TempData["ResultMessage"] = String.Format("item {0} edit complete",postback.itemName);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(postback);
            }
        }
        public ActionResult Delete(int id)
        {
            using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
            {
                var result = (from s in db.Item where s.itemID == id select s).FirstOrDefault();
                if (result != default(Models.DB.Item))
                {
                    db.Item.Remove(result);
                    db.SaveChanges(); 
                    TempData["ResultMessage"] = String.Format("item {0} delete complete", result.itemName);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ResultMessage"] = "item not found, delete fail";
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Upload(int id)
        {
            using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
            {
                var result = (from s in db.Item where s.itemID == id select s).FirstOrDefault();
                if (result != default(Models.DB.Item))
                {
                    HttpContext.Session["PB"] = result;
                    
                    return View(result);
                    
                }
                else
                {
                    TempData["ResultMessage"] = "Searching not found, please choose again";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                Stream img = file.InputStream;
                BinaryReader br = new BinaryReader(img);
                byte[] bytes = br.ReadBytes((Int32)img.Length);
                Models.DB.Item obj = (Models.DB.Item)Session["PB"];
                using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
                {
                    var imgObj = (from s in db.Item where s.itemID == obj.itemID select s).FirstOrDefault();
                    imgObj.itemID = obj.itemID;
                    imgObj.itemName = obj.itemName;
                    imgObj.imgdata = bytes;
                    db.SaveChanges();
                    TempData["resultMessage"] = String.Format("item 「{0}」 image uploaded.", obj.itemName);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["ResultMessage"] = "upload null, please check";
                return RedirectToAction("Index");
            }
            /*byte[] bytes;
            using (BinaryReader br = new BinaryReader(file.InputStream))
            {
                bytes = br.ReadBytes(file.ContentLength);
            }
            Models.DB.MVCEntities ent = new Models.DB.MVCEntities();
            ent.Item.Add(new Models.DB.Item {
            imgdata = bytes
            });
            ent.SaveChanges();
            TempData["ResultMessage"] = "upload success, please check";
            return RedirectToAction("Index");*/

            /* //byte[] bytes = new byte[imgdata.ContentLength];
            Stream img = imgdata.InputStream;
            BinaryReader br = new BinaryReader(img);
            byte[] bytes = br.ReadBytes((Int32)img.Length);
            //{
            //bytes = br.ReadBytes((Int64)imgdata.ContentLength);
            //}
            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Models.DB.Item obj = (Models.DB.Item)Session["PB"];
            using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())

            {
                var imgObj = (from s in db.Item where s.itemID == obj.itemID select s).FirstOrDefault();
                imgObj.itemID = obj.itemID;
                imgObj.itemName = obj.itemName;
                imgObj.imgdata = bytes;
                db.SaveChanges();
                TempData["resultMessage"] = String.Format("item 「{0}」 image uploaded.", obj.itemName);
                return RedirectToAction("Index");
            }*/
        }

    }
}