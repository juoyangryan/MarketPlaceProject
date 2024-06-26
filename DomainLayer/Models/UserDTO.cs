﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class UserDTO
    {
        public int ID { get; set; }
        
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ProfilePicture { get; set; }
    }
}
