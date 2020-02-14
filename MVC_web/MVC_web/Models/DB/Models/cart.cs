using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    [Serializable]
    public class Cart : IEnumerable<CartItem> //購物車類別
    {
            //建構值
            public Cart()
            {
                this.cartItems = new List<CartItem>();
            }

            //儲存所有商品
            private List<CartItem> cartItems;

            /// <summary>
            /// 取得購物車內商品的總數量
            /// </summary>
            public int Count
            {
                get
                {
                    return this.cartItems.Count;
                }
            }

            //取得商品總價
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

            //新增一筆Product，使用ProductId
            public bool AddItem(int itemID)
            {
                var findItem = this.cartItems
                                .Where(s => s.iID == itemID)
                                .Select(s => s)
                                .FirstOrDefault();

                //判斷相同Id的CartItem是否已經存在購物車內
                if (findItem == default(Models.CartItem))
                {   //不存在購物車內，則新增一筆
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
                {   //存在購物車內，則將商品數量累加
                    findItem.qty += 1;
                }
                return true;
            }

            //新增一筆Product，使用Product物件
            private bool AddItem(Item item)
            {
                //將Product轉為CartItem
                var cartItem = new Models.CartItem()
                {
                    iID = item.itemID,
                    iName = item.itemName,
                    iprice = item.iPrice,
                    qty = 1
                };

                //加入CartItem至購物車
                this.cartItems.Add(cartItem);
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