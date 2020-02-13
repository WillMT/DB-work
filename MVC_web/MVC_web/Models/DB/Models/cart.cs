using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    [Serializable]
    public class cart
    {
        public cart()
        {
            this.cartItems = new List<cartItem>();
        }
        public List<cartItem> cartItems;
        public decimal total
        {
            get
            {
                decimal total = 0.0m;
                foreach(var cartItem in this.cartItems)
                {
                    total = total + cartItem.Amount;
                }
                return total;
            }
        }
    }
}