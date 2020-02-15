using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    [Serializable]
    public class Cart : IEnumerable<CartItem> 
    {
            public Cart()
            {
                this.cartItems = new List<CartItem>();
            }


            private List<CartItem> cartItems;

            public int Count
            {
                get
                {
                    return this.cartItems.Count;
                }
            }

            public decimal TotalAmount
            {
                get
                {
                    decimal totalAmount = 0.0m;
                    foreach (var cartItem in this.cartItems)
                    {
                        totalAmount = totalAmount + cartItem.Amount;
                    }
                    return totalAmount;
                }
            }

            public bool AddItem(int itemID)
            {
                var findItem = this.cartItems
                                .Where(s => s.iID == itemID)
                                .Select(s => s)
                                .FirstOrDefault();

                if (findItem == default(Models.CartItem))
                { 
                    using (MVCEntities db = new MVCEntities())
                    {
                        var icart = (from s in db.Item
                                       where s.itemID == itemID
                                       select s).FirstOrDefault();
                        if (icart != null)
                        {
                            this.AddItem(icart);
                        }
                    }
                }
                else
                {
                    findItem.qty += 1;
                }
                return true;
            }

            private bool AddItem(Item item)
            {
                var cartItem = new Models.CartItem()
                {
                    iID = item.itemID,
                    iName = item.itemName,
                    iprice = item.iPrice,
                    qty = 1
                };
                this.cartItems.Add(cartItem);
                return true;
            }
            
            public bool RemoveItem(int id)
            {
            var searchItem = this.cartItems.Where(s => s.iID == id).Select(s => s).FirstOrDefault();
                if (searchItem == default(Models.CartItem))
                {

                }
                else
                {
                    this.cartItems.Remove(searchItem);
                }
            return true;
            }
            public List<OIL> ToOrderDetailList(int orderId)
            {
                var result = new List<OIL>();
                foreach (var cartItem in this.cartItems)
                {
                    result.Add(new OIL()
                    {
                        OID = orderId,
                        iName= cartItem.iName,
                        iprice = cartItem.iprice,
                        qty = cartItem.qty,
                        iID = cartItem.iID
                    });
                }
                return result;
            }

        public bool ClearCart()
            {
            this.cartItems.Clear();
            return true;
            }
            

            #region IEnumerator

            IEnumerator<CartItem> IEnumerable<CartItem>.GetEnumerator()
            {
                return this.cartItems.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.cartItems.GetEnumerator();
            }

            #endregion
        }
    
}