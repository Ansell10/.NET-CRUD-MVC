using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_CRUD_MVC.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
        }
        [Required(ErrorMessage = "UserName is required")]
        public String UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public String Password { get; set; }

    }
}

