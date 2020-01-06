using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCweb.Models.ViewModel
{
    public class AdminSignUpView
    {
        [Key]
        [Required(ErrorMessage = "*")]
        [Display(Name = "LOGIN NAME")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}