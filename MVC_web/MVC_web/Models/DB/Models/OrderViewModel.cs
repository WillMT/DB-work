using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    public class OrderViewModel
    {
        public IEnumerable<OrderInfo> OrderinfoList { get; set; }
        public IEnumerable<OIL> OrderItemList { get; set; }
    }
}