using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    public class itemViewModel
    {
       public IEnumerable<Item> DrinkList { get; set; }
       public IEnumerable<Item> FoodList { get; set; }
       public IEnumerable<Item> itemList { get; set; }
    }
}