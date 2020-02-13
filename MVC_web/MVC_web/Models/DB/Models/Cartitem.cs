using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    [Serializable]
    public class cartItem
    {
        public int iID { get; set; }
        public String iName { get; set; }
        public decimal iprice { get; set; }
        public int qty { get; set; }

        public decimal Amount
        {
            get
            {
                return this.iprice * this.qty;
            }
        }
    }
}