using System;
using System.IO;
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
            ViewBag.ResultMessage = TempData["ResultMessage"];
            using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
            {
                itemList = (from s in db.Item select s).ToList();
                return View(itemList);


            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.DB.Item postback, HttpPostedFileBase imgdata)
        {
            if (this.ModelState.IsValid)
            {

                byte[] bytes;
                using (BinaryReader br = new BinaryReader(imgdata.InputStream))
                {
                    bytes = br.ReadBytes((Int32)imgdata.ContentLength);
                }
                using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
                {
                    if (bytes != null)
                    {
                        db.Item.Add(postback);
                        Models.DB.Item items = new Models.DB.Item();
                        items.imgdata = bytes;

                        db.SaveChanges();
                        TempData["ResultMessage"] = String.Format("item 「{0}」 add successful with image", postback.itemName);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        db.Item.Add(postback);
                        db.SaveChanges();
                        TempData["ResultMessage"] = String.Format("item 「{0}」 add successful without image", postback.itemName);
                        return RedirectToAction("Index");
                    }
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
                    return View(result);
                }
                else
                {
                    TempData["resultMessage"] = "Searching not found, please choose again";
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
                    TempData["resultMessage"] = "Searching not found, please choose again";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase image)
        {
            if (image != null)
            {
                TempData["resultMessage"] = "img upload not null";
                return RedirectToAction("Index");
            } else
            {
                TempData["resultMessage"] = "img upload is null";
                return RedirectToAction("Index");
            }
            
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