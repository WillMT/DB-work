using System.Web.Mvc;


namespace MVCcafe_web.Controllers
{
    
    
    public class MenuController : Controller
    {
        
        public ActionResult Food()
        {
            return View();
        }
        
        public ActionResult Drink()
        {
            return View();
        }
    }
}
