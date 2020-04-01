using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileModels
{
    public class ProfileUpdate
    {
        [Range(1, 50)]
        public string FirstName { get; set; }
        [Range(1, 50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(3, 15)]
        public string UserName { get; set; }
    }
}
