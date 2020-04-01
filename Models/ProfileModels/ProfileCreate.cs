using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileModels
{
    public class ProfileCreate
    {
        [Required]
        [Range(1, 50)]
        public string FirstName { get; set; }
        [Required]
        [Range(1, 50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(3, 15)]
        public string UserName { get; set; }
    }
}
