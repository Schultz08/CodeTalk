﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileModels
{
    public class ProfileCreate
    {
        public string ProfileId { get; set; }
       
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
       
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
