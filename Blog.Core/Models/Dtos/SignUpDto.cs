using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Dtos
{
    public class SignUpDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Address { get; set; }
        [RegularExpression(@"^\+[1-9]0\d{10}$", ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email is already in use")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password Should Be At least 6 characters")]
        public string Password { get; set; }
    }
}
