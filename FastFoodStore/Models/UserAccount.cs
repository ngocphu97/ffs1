using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FastFoodStore.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="FirstName is required")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
    }
}