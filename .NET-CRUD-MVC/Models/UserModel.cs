using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_CRUD_MVC.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public String Password { get; set; }

    }
}

