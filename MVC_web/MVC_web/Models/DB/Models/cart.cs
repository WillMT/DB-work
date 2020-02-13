using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    [Serializable]
    public class cart : IEnumerable<cartItem>
    {
        public cart()
        {
            this.cartItems = new List<cartItem>();
        }

        private List<cartItem> cartItems;
        public decimal total
        {
            get
            {
                return this.cartItems.Count;
            }
        }
    }
}