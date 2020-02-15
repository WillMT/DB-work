using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    public class OIL
    {
        [Key]
        public int OILid { get; set; }

        public int OID { get; set; }

        public int iID { get; set; }

        public string iName { get; set; }

        public decimal iprice { get; set; }

        public int qty { get; set; }

        public virtual OrderInfo OrderInfo { get; set; }
        public virtual Item Item { get; set; }
    }
}