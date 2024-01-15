﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Trial_Exam.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
