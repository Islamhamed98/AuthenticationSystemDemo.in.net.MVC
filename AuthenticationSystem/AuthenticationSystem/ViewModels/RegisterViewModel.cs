using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Please enter username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please enter Confirmation password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("UserPassword" , ErrorMessage = "Ohh , Two Passwords Dosn't Match !! ")]
        public string ConfirmPassword { get; set; }
         
    }
}