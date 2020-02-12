using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_web.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.DB.admin postback)
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            using (Models.DB.MVCEntities db = new Models.DB.MVCEntities())
            {
                var result = (from s in db.admin where s.aName == postback.aName && s.aPwd == postback.aPwd select s).FirstOrDefault();
                //if (result != default(Models.DB.admin))
                if (result != null)
                {
                    TempData["ResultMessage"] = String.Format("Username : {0} login success.", postback.aName);
                    return RedirectToAction("Index","item");
                }
                else
                {
                    TempData["ResultMessage"] = String.Format("Username : {0} password not match.", postback.aName);
                    return View();
                }
            }
        }

        public ActionResult Login()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Username, String Password)
        {
            {
                bool Flag = PM.CheckUserID(UserID);
                string LevelID = string.Empty;
                if (Flag)
                {
                    List<User> list = PM.CheckLogin(UserID, Password); //請自行實作檢查帳密，撈出資料

                    if (list.Count == 0)
                    {
                        TempData["Error"] = "您輸入的帳號不存在或者密碼錯誤!";
                        return View();
                    }
                    else
                    {
                        foreach (var Itme in list)
                        {
                            LevelID = Itme.LevelID.ToString();
                        }

                        LoginProcess(LevelID, UserID, false); //表單驗證方法
                        return RedirectToAction("Index", "User");
                    }
                }
                return View();
            }
        }

        private void LoginProcess(string level, string id, bool isRemeber)
        {
            var now = DateTime.Now;

            string roles = level;
            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: id.ToString(), //這邊看個人，你想放使用者名稱也可以，自行更改
                issueDate: now,//現在時間
                expiration: now.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
                isPersistent: isRemeber,//記住我 true or false
                userData: roles, //這邊可以放使用者名稱，而我這邊是放使用者的群組代號
                cookiePath: FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        }
    }
}