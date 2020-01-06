using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCweb.Models.ViewModel;
using MVCweb.Models.Entity;

namespace MVCweb.Controllers
{
    public class AdminController : Controller
    {
      public ActionResult SignUp()
        {
            return View();
        }

     [HttpPost]
     public ActionResult SignUp(AdminSignUpView ASU)
        {
            if (ModelState.IsValid)
            {
                AdminManager AM = new AdminManager();
                if (!AM.IsUsernNameExist(ASU.Username))
                {
                    AM.AddAdminAcc(ASU);
                    FormsAuthentication.SetAuthCookie(ASU.Username, false);
                    return RedirectToAction("Welcome", "admin");
                }
                else
                    ModelState.AddModelError("", "This User Name Already Taken.");
            }
            return View();
        }
    }
}