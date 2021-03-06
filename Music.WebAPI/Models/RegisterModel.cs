﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Music.WebAPI.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
        
        public DateTime BirthDay { get; set; }
    }
}
