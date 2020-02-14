using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_web.Models.DB.Models
{
    public class OrderInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Customer name")]
        [StringLength(30)]
        public string CusName { get; set; }

        [Required]
        [Display(Name = "phone")]
        [StringLength(8,ErrorMessage ="{0} must have {2} digit", MinimumLength =8)]
        public string CusPhone { get; set; }

        [Display(Name ="Table no. (if have)")]
        public int TableNo { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }

    /*public static List<OrderInfo> getInfo()
    {
        List<OrderInfo> oInfo = new List<OrderInfo>
        {
            new OrderInfo
            {
                OrderID = 1,
                CusName = "testinfo",
                CusPhone = "12345678",
                TableNo = 2
            }
         return oInfo;

    }   
    }*/
}