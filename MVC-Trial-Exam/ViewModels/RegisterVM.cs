﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Trial_Exam.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required ,DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
