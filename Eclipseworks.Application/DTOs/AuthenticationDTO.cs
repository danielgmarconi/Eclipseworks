﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Application.DTOs
{
    public class AuthenticationDTO
    {
        [Required(ErrorMessage = "The E-mail is required.")]
        [MinLength(10, ErrorMessage = "The Name must be at least 3 characters long.")]
        [MaxLength(250, ErrorMessage = "The name can have a maximum of 200 characters.")]
        [EmailAddress(ErrorMessage = "Invalid E-mail")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [MinLength(8, ErrorMessage = "The Name must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$",
         ErrorMessage = "The password must be between 8 and 20 characters long, including at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
