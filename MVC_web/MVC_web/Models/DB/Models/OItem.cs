using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    public class OItem
    {
        [Key, ForeignKey("OrderInfo"), Column(Order = 0)]
        public int OrderID { get; set; }

        [Key, ForeignKey("Item"), Column(Order = 1)]
        public int itemID { get; set; }

        public string iName { get; set; }

        public decimal iprice { get; set; }

        public int qty { get; set; }

        [ForeignKey("OrderID,itemID")]
        public virtual OrderInfo OrderInfo { get; set; }
        public virtual Item Item { get; set; }
    }
}