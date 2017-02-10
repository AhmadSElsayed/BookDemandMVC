using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookWebApplication.Models
{
    public class UserModel
    {
        public UserModel()
        {
            error = false;
        }
        [Required(ErrorMessage = "Please Enter another Username")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please Enter a password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please Enter a Library")]
        public string Library { get; set; }
        public bool error { get; set; }
    }
}