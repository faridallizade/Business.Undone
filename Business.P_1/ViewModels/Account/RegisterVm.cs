﻿using System.ComponentModel.DataAnnotations;

namespace Business.P_1.ViewModels.Account
{
    public class RegisterVm
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Surname { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
    }
}
