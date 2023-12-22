using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_CRUD_MVC.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is invalid")]
        public String PhoneNumber { get; set; }
    }
}

