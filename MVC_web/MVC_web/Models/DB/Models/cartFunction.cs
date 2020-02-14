using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MVC_web.Models.DB.Models
{
    public class cartFunction
    {
        [WebMethod(EnableSession = true)]
        public static Cart GetCurrCart()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["Cart"] == null)
                {
                    var ordercart = new Cart();
                    HttpContext.Current.Session["Cart"] = ordercart;
                }
                return(Cart)HttpContext.Current.Session["Cart"];
            }
            else
            {
                throw new InvalidOperationException("null,please check");
            }
        }
        public static List<OrderInfo> getInfo()
        {
            List<OrderInfo> oInfo = new List<OrderInfo>
            {
                new OrderInfo
                {
                    OrderID = 1,
                    CusName = "testinfo",
                    CusPhone = "12345678",
                    TableNo = 2
                }
            };

            return oInfo;
        }
    }
}