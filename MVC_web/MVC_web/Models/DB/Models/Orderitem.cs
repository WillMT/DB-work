using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    public class OrderItem
    {
        public int OID;

        public int iID;

        public string iName;

        public decimal iprice;

        public int qty;

        public virtual OrderInfo OrderInfo { get; set; }
        public virtual Item Item { get; set; }
    }
}