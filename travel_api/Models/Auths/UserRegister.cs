﻿using System.ComponentModel.DataAnnotations;

namespace travel_api.Models.Auths
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Username is required!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid Email!")]
        public string? Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public int? CityId { get; set; }
    }
}
