using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_web.Controllers
{
    public class ItemInfoController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "no id value" };
        }
        public string Get(int id)
        {
            Models.DB.MVCEntities db = new Models.DB.MVCEntities();
            var result = (from s in db.Item where s.itemID == id select s).FirstOrDefault();
            var str = ("ID : "+id+ " name is : "+result.itemName);
            return str;
        }
    }
}
